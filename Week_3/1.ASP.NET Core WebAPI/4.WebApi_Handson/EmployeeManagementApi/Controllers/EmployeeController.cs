using EmployeeManagementApi.Filters;
using EmployeeManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = GetStandardEmployeeList();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required.");
            }

            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Permanent = employee.Permanent;
            existingEmployee.Department = employee.Department;
            existingEmployee.Skills = employee.Skills;
            existingEmployee.DateOfBirth = employee.DateOfBirth;

            return Ok(existingEmployee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            employees.Remove(employee);

            return Ok("Employee deleted successfully.");
        }

        private static List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department
                    {
                        Id = 1,
                        Name = "IT"
                    },
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new Skill
                        {
                            Id = 2,
                            Name = "ASP.NET Core"
                        }
                    },
                    DateOfBirth = new DateTime(1995, 5, 15)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Salary = 65000,
                    Permanent = false,
                    Department = new Department
                    {
                        Id = 2,
                        Name = "HR"
                    },
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id = 3,
                            Name = "Recruitment"
                        }
                    },
                    DateOfBirth = new DateTime(1992, 8, 25)
                }
            };
        }
    }
}