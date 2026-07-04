using EmployeeJwtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeJwtApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin,POC")]
    //[Authorize(Roles = "POC")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(GetStandardEmployeeList());
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Name="John",
                    Salary=50000,
                    Permanent=true,
                    DateOfBirth=new DateTime(1998,5,10),

                    Department=new Department
                    {
                        Id=1,
                        Name="IT"
                    },

                    Skills=new List<Skill>
                    {
                        new Skill
                        {
                            Id=1,
                            Name="C#"
                        },
                        new Skill
                        {
                            Id=2,
                            Name="ASP.NET Core"
                        }
                    }
                },

                new Employee
                {
                    Id=2,
                    Name="Jane",
                    Salary=60000,
                    Permanent=false,
                    DateOfBirth=new DateTime(1997,2,20),

                    Department=new Department
                    {
                        Id=2,
                        Name="HR"
                    },

                    Skills=new List<Skill>
                    {
                        new Skill
                        {
                            Id=3,
                            Name="SQL"
                        }
                    }
                }
            };
        }
    }
}