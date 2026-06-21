using System;

namespace FinancialForecasting
{
    public class ForecastingLogic
    {
        // Recursive method to calculate future value
        // Formula: Future Value = Current Value * (1 + Growth Rate)
        public static double CalculateValue(double currentValue, double growthRate, int years)
        {
            // Base Case: If no more years to predict, return the current value
            if (years == 0)
            {
                return currentValue;
            }

            // Recursive Step: Calculate value for the next year
            double nextYearValue = currentValue * (1 + growthRate);

            // Move to the next year
            return CalculateValue(nextYearValue, growthRate, years - 1);
        }
    }
}