# Web API Handson 3: Working with Custom Models, Action Filters and Exception Filters

## Scenario

Enterprise Web APIs commonly exchange complex business objects instead of primitive data types. They also validate incoming requests, secure endpoints, and handle unexpected exceptions in a centralized manner.

In this handson, I created an Employee Management Web API that returns a list of custom Employee objects, accepts Employee objects from the request body, validates Authorization headers using a custom action filter, and handles unhandled exceptions using a custom exception filter. Swagger UI was used to test all API endpoints and verify the filter behavior.

## Objective

The objective of this handson is to:

* Create a custom Employee model containing nested Department and Skill objects.
* Return a list of Employee objects using an HTTP GET action.
* Demonstrate the usage of the `[FromBody]` attribute with POST and PUT requests.
* Implement a custom authorization filter using `ActionFilterAttribute`.
* Validate Authorization headers before executing controller actions.
* Implement a global custom exception filter.
* Log exceptions into a text file.
* Test all API endpoints using Swagger UI.

## Project Structure

The project was implemented using an ASP.NET Core Web API project named **EmployeeManagementApi**.

The following folders and files were created during the implementation.

```text
EmployeeManagementApi
│
├── Controllers
│   └── EmployeeController.cs
│
├── Filters
│   ├── CustomAuthFilter.cs
│   └── CustomExceptionFilter.cs
│
├── Models
│   ├── Employee.cs
│   ├── Department.cs
│   └── Skill.cs
│
├── Program.cs
│
└── ErrorLog.txt
```

## Implementation Steps

### Step 1: Create the Custom Model Classes

Three model classes were created inside the **Models** folder.

* Employee
* Department
* Skill

The `Employee` class contains employee information such as Id, Name, Salary, Permanent status, Date of Birth, Department information, and a collection of employee skills.

The Department and Skill classes represent nested objects within the Employee model.

### Step 2: Create EmployeeController

A new controller named `EmployeeController` was created.

The controller contains:

* HTTP GET action
* HTTP POST action
* HTTP PUT action

A private method named `GetStandardEmployeeList()` returns a list of Employee objects which is used by the GET action.

Example:

```csharp
private List<Employee> GetStandardEmployeeList()
{
    return new List<Employee>
    {
        ...
    };
}
```

The GET action returns the employee list.

```csharp
[HttpGet]
public ActionResult<List<Employee>> Get()
{
    return GetStandardEmployeeList();
}
```

### Step 3: Use ProducesResponseType

The GET action was decorated using `ProducesResponseType`.

```csharp
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
```

This documents the possible HTTP responses inside Swagger UI.

### Step 4: Demonstrate FromBody Attribute

The POST action accepts an Employee object from the request body.

```csharp
[HttpPost]
public IActionResult Post([FromBody] Employee employee)
{
    return Ok(employee);
}
```

Similarly, the PUT action also accepts an Employee object from the request body.

```csharp
[HttpPut]
public IActionResult Put([FromBody] Employee employee)
{
    return Ok(employee);
}
```

The `[FromBody]` attribute instructs ASP.NET Core to deserialize the JSON request body into an Employee object automatically.

### Step 5: Create Custom Authorization Filter

A new folder named **Filters** was created.

Inside this folder, `CustomAuthFilter.cs` was implemented by inheriting from `ActionFilterAttribute`.

The filter checks whether the request contains an Authorization header.

If the Authorization header is missing, the filter returns:

```text
Invalid request - No Auth token
```

If the Authorization header exists but does not contain the word **Bearer**, the filter returns:

```text
Invalid request - Token present but Bearer unavailable
```

Only valid requests are allowed to execute the controller action.

The filter was applied to the controller using:

```csharp
[CustomAuthFilter]
```

### Step 6: Create Global Exception Filter

A second filter named `CustomExceptionFilter` was created.

The filter inherits from `ExceptionFilterAttribute`.

Whenever an unhandled exception occurs, the filter:

* Captures the exception.
* Writes the exception details into `ErrorLog.txt`.
* Returns an HTTP 500 Internal Server Error response.

The filter was registered globally inside `Program.cs`.

```csharp
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});
```

This ensures that every controller in the application uses the exception filter automatically.

### Step 7: Execute the Application

The application was executed using Swagger UI.

The following operations were verified successfully.

* GET Employee List
* POST Employee
* PUT Employee
* Authorization validation
* Exception handling
* Exception logging

## Output

The following screenshots demonstrate the successful execution of the application.

### Project Execution

![Swagger GET Employees](Screenshots/swagger_get_employees.png)

This screenshot shows:

* Employee API listed in Swagger.
* Successful execution of the GET action.
* Employee list returned as the response.

![Swagger POST Request](Screenshots/swagger_post_request.png)

This screenshot shows:

* POST request executed from Swagger.
* Employee object submitted through the request body.

![Swagger PUT Response](Screenshots/swagger_put_response.png)

This screenshot shows:

* Successful execution of the PUT request.
* Updated Employee object returned in the response.

### Custom Authorization Filter

![Missing Authorization Header](Screenshots/auth_missing_header.png)

This screenshot shows:

* Request executed without the Authorization header.
* CustomAuthFilter returning the message:
  `Invalid request - No Auth token`.

![Invalid Authorization Token](Screenshots/auth_invalid_token.png)

This screenshot shows:

* Authorization header provided without the required Bearer keyword.
* CustomAuthFilter returning the message:
  `Invalid request - Token present but Bearer unavailable`.

![Successful Authorization](Screenshots/auth_success.png)

This screenshot shows:

* Request executed with a valid Authorization header.
* Controller action executed successfully.
* Employee list returned.

### Custom Exception Filter

![Exception Response](Screenshots/exception_response.png)

This screenshot shows:

* An exception intentionally generated inside the controller.
* HTTP 500 Internal Server Error returned.
* Exception captured by the application.

![Error Log](Screenshots/error_log.png)

This screenshot shows:

* Exception details written into `ErrorLog.txt`.
* Successful logging of application errors.

## Analysis

### Returning Custom Objects

Instead of returning primitive values, the API returns strongly typed Employee objects containing nested Department and Skill information.

This allows structured business data to be exchanged between clients and servers.

### FromBody Attribute

The `[FromBody]` attribute instructs ASP.NET Core to deserialize JSON data received in the HTTP request body into a strongly typed C# object.

It is commonly used with POST and PUT requests where complex objects are transmitted.

### Custom Authorization Filter

The custom authorization filter intercepts incoming requests before the controller action executes.

It validates whether:

* The Authorization header exists.
* The Authorization header contains the required Bearer token.

If validation fails, the request is terminated immediately with an appropriate HTTP response.

This keeps authorization logic separate from business logic.

### Custom Exception Filter

The global exception filter captures unhandled exceptions generated by controller actions.

Instead of allowing the application to crash, it:

* Logs exception details.
* Returns an HTTP 500 response.
* Provides centralized exception handling for the entire application.

Centralized exception handling improves maintainability and simplifies application debugging.

## Result

Thus, a Web API was successfully implemented using custom model classes, custom action filters, and a global exception filter.

The API successfully demonstrated returning complex Employee objects, accepting JSON request bodies using the `[FromBody]` attribute, validating Authorization headers through a custom authorization filter, handling application exceptions using a global exception filter, and logging exceptions to a text file while testing all functionality using Swagger UI.