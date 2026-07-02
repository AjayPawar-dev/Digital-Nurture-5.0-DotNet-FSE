using EmployeeManagementApi.Filters;
using EmployeeManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            return GetStandardEmployeeList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            return Ok(employee);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            return Ok(employee);
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Ajay Pawar",
                    Salary = 80000,
                    Permanent = true,
                    DateOfBirth = new DateTime(2000, 5, 20),

                    Department = new Department
                    {
                        Id = 101,
                        Name = "Information Technology"
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
                            Name = ".NET"
                        }
                    }
                },

                new Employee
                {
                    Id = 2,
                    Name = "Rahul Sharma",
                    Salary = 65000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1998, 9, 12),

                    Department = new Department
                    {
                        Id = 102,
                        Name = "Human Resources"
                    },

                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id = 3,
                            Name = "Communication"
                        },
                        new Skill
                        {
                            Id = 4,
                            Name = "Recruitment"
                        }
                    }
                }
            };
        }
    }
}