using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemoApi.Models;

namespace SwaggerDemoApi.Controllers
{
    [ApiController]
    [Route("api/Emp")]   // Route changed from Employee to Emp
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> employees =
        [
            new Employee
            {
                Id = 1,
                Name = "Ajay",
                Department = "IT",
                Salary = 50000
            },

            new Employee
            {
                Id = 2,
                Name = "Rahul",
                Department = "HR",
                Salary = 45000
            }
        ];

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return Created("", employee);
        }
    }
}