using FinancialForecasting;

class Program
{
    static void Main(string[] args)
    {
        // 1. Setup Initial Data
        double initialInvestment = 1000.00; // Starting amount
        double annualGrowthRate = 0.05;     // 5% growth
        int projectionYears = 10;           // Predict for 10 years

        Console.WriteLine("--- Financial Forecasting Tool ---");
        Console.WriteLine($"Initial Value: ${initialInvestment}");
        Console.WriteLine($"Annual Growth Rate: {annualGrowthRate * 100}%");
        Console.WriteLine($"Projection Period: {projectionYears} years");

        // 2. Execute Recursive Logic
        double futureValue = ForecastingLogic.CalculateValue(initialInvestment, annualGrowthRate, projectionYears);

        // 3. Display Result
        Console.WriteLine("\n--- Results ---");
        Console.WriteLine($"Predicted Future Value: ${Math.Round(futureValue, 2)}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}