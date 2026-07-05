using EmployeeKafkaApi.Models;
using EmployeeKafkaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeKafkaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IKafkaProducerService _producerService;

        public EmployeeController(IKafkaProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            await _producerService.ProduceAsync(employee);

            return Ok("Employee sent to Kafka successfully.");
        }
    }
}