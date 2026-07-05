namespace EmployeeKafkaApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Salary { get; set; }

        public bool Permanent { get; set; }
    }
}