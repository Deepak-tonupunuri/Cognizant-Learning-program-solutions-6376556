using System;
using System.Collections.Generic;

class FinancialForecast
{
    public static double PredictFutureValue(int year, double initialValue, double growthRate)
    {
        if (year == 0)
            return initialValue;
        return PredictFutureValue(year - 1, initialValue, growthRate) * (1 + growthRate);
    }

    public static double PredictFutureValueMemo(int year, double initialValue, double growthRate, Dictionary<int, double> memo)
    {
        if (year == 0)
            return initialValue;
        if (memo.ContainsKey(year))
            return memo[year];

        memo[year] = PredictFutureValueMemo(year - 1, initialValue, growthRate, memo) * (1 + growthRate);
        return memo[year];
    }

    static void Main(string[] args)
    {
        double initialValue = 500;  
        double growthRate = 0.02;    
        int targetYear = 5;

        Console.WriteLine("Recursive Forecast (No Memoization):");
        Console.WriteLine($"Value after {targetYear} years: {PredictFutureValue(targetYear, initialValue, growthRate):F2}");

        Console.WriteLine("\nRecursive Forecast (With Memoization):");
        var memo = new Dictionary<int, double>();
        Console.WriteLine($"Value after {targetYear} years: {PredictFutureValueMemo(targetYear, initialValue, growthRate, memo):F2}");
    }
}