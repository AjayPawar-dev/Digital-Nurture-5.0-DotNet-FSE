using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]   // Creates URL:/api/values because controller name is ValuesController
    [ApiController]               // Marks the class as a Web API Controller.
    public class ValuesController : ControllerBase
    {
        [HttpGet]                  // Responds when client sends: GET /api/values
        public IActionResult Get()
        {
            return Ok("GET Request Executed Successfully");
        }

        [HttpPost]                 // Responds when client sends: POST /api/values
        public IActionResult Post()
        {
            return Ok("POST Request Executed Successfully");  // Returns: HTTP 200 success response.
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("PUT Request Executed Successfully");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("DELETE Request Executed Successfully");
        }
    }
}
