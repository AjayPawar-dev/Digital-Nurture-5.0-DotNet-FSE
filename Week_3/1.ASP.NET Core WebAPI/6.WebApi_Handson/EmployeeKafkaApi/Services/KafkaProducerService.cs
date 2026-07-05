using Confluent.Kafka;
using EmployeeKafkaApi.Models;
using System.Text.Json;

namespace EmployeeKafkaApi.Services
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IProducer<Null, string> _producer;
        private const string Topic = "employee-topic";

        public KafkaProducerService()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceAsync(Employee employee)
        {
            string message = JsonSerializer.Serialize(employee);

            await _producer.ProduceAsync(
                Topic,
                new Message<Null, string>
                {
                    Value = message
                });

            Console.WriteLine($"Message sent to Kafka: {message}");
        }
    }
}