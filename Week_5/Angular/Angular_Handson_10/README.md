# Hands-On 10 – Unit Testing Angular Applications (Jasmine, TestBed & Http Testing)

## Objective

The objective of this hands-on is to learn unit testing in Angular using Jasmine and Angular TestBed. This includes testing standalone components, verifying @Input and @Output behavior, testing lifecycle hooks, testing services using HttpClientTestingModule, mocking HTTP requests with HttpTestingController, and validating error handling.

# Project Structure (up to Hands-On 10)

```text
src
│
├── app
│
├── components
│   ├── course-card
│   │   ├── course-card.ts
│   │   ├── course-card.html
│   │   └── course-card.spec.ts
│   │
│   ├── header
│   ├── notification
│   └── course-summary-widget
│
├── services
│   ├── course.ts
│   └── course.spec.ts
│
├── models
│   └── course.model.ts
│
├── pages
│   ├── course-list
│   ├── course-detail
│   ├── home
│   └── ...
│
├── app.spec.ts
│
└── ...
```

# Implementation

## Task 1 – Configure TestBed

Configured Angular TestBed for the standalone CourseCard component.

```typescript
beforeEach(async () => {

  await TestBed.configureTestingModule({

    imports: [CourseCard]

  }).compileComponents();

  fixture = TestBed.createComponent(CourseCard);

  component = fixture.componentInstance;

});
```

This prepares the Angular testing environment before every test.

 

## Task 2 – Component Creation Test

Verified that the component is successfully created.

```typescript
it('should create', () => {

  expect(component).toBeTruthy();

});
```

This confirms that Angular can instantiate the component without errors.

 

## Task 3 – Testing @Input Rendering

Assigned a mock Course object to the component and verified that the course name appears in the rendered HTML.

```typescript
component.course = mockCourse;

fixture.detectChanges();

const heading =
fixture.debugElement.query(By.css('h3'));

expect(
heading.nativeElement.textContent
).toContain('Data Structures');
```

This validates Angular's data binding from the component class to the template.

 

## Task 4 – Testing @Output Events

Verified that clicking the Enroll button emits the correct course ID.

```typescript
vi.spyOn(component.enrollRequested, 'emit');

fixture.debugElement
.query(By.css('button'))
.nativeElement.click();

expect(
component.enrollRequested.emit
).toHaveBeenCalledWith(1);
```

This ensures that parent components receive the correct event data.

 

## Task 5 – Testing Component Methods

Verified the enroll() method updates the component state.

```typescript
component.enroll();

expect(component.isEnrolled)
.toBe(true);
```

This confirms that component logic behaves correctly.

 

## Task 6 – Testing ngOnChanges

Verified that ngOnChanges executes and logs the expected information.

```typescript
const logSpy =
vi.spyOn(console, 'log');

component.ngOnChanges({

course: new SimpleChange(
null,
mockCourse,
true
)

});

expect(logSpy)
.toHaveBeenCalled();
```

This confirms that Angular lifecycle hooks execute as expected.

 

## Task 7 – Testing CourseService

Configured HttpClientTestingModule and injected HttpTestingController.

```typescript
TestBed.configureTestingModule({

imports: [

HttpClientTestingModule

],

providers: [

CourseService

]

});
```

This replaces real HTTP calls with mock requests during testing.

 

## Task 8 – Testing HTTP GET Request

Verified that CourseService requests the correct API endpoint.

```typescript
service.getCourses()
.subscribe(courses => {

expect(courses.length)
.toBe(2);

});

const request =
httpMock.expectOne(
'http://localhost:3000/courses'
);

request.flush(mockCourses);
```

The service correctly retrieves course data from the mocked backend.

 

## Task 9 – Testing Error Handling

Verified that the service returns the expected error when the server responds with an error.

```typescript
request.flush(

'Server Error',

{

status:500,

statusText:'Server Error'

}

);

expect(error.message)
.toContain(
'Failed to load courses'
);
```

This confirms that catchError() correctly transforms HTTP errors into user-friendly messages.

# Output

## Task 1 – Component Tests Passing

Shows all CourseCard component unit tests executing successfully.

![CourseCard Tests](Screenshots/op1.png)

 

## Task 2 – Course-Detail Tests Passing

Shows CourseService tests passing using HttpTestingController.

![CourseService Tests](Screenshots/op2.png)

 

## Task 3 – Complete Test Execution

Shows all implemented Hands-On 10 tests passing successfully.

![All Tests Passing](Screenshots/op3.png)

# Learning Outcomes

After completing this hands-on, I learned how to:

* Configure Angular TestBed for standalone components.
* Write unit tests using Jasmine/Vitest syntax.
* Test Angular components.
* Verify @Input data binding.
* Test @Output EventEmitter events.
* Test component methods.
* Test Angular lifecycle hooks.
* Mock HTTP requests using HttpTestingController.
* Validate REST API calls without a real backend.
* Test HTTP error handling using mocked responses.
* Understand how Angular unit testing isolates components and services.

# Result

Successfully implemented unit tests for Angular standalone components and services using TestBed and HttpClientTestingModule. Verified component rendering, input and output bindings, lifecycle hooks, service HTTP requests, and error handling, ensuring the Student Course Portal behaves correctly through automated unit testing.