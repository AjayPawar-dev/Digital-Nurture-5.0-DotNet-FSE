using EmployeeKafkaApi.Models;

namespace EmployeeKafkaApi.Services
{
    public interface IKafkaProducerService
    {
        Task ProduceAsync(Employee employee);
    }
}