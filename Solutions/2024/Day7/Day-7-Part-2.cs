// To see puzzle description, see README

// Time complexity:  O(m * n * 3 ^ n), where n is the amount of numbers in each line and m is the amount of lines
// Execution time: 1885 miliseconds (double yikes! will be optimized later)

using System;
using System.Diagnostics;
using System.Numerics; 

class Day7Part2_2024
{
    public static void ExecuteDay7Part2()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Define and read input
        string day7Input = "Solutions/2024/Day7/Inputs/Day7Input.txt";
        string[] lines = File.ReadAllLines(day7Input);

        // Define the total counter
        BigInteger totalCounter = 0;

        // Change input into Big Integeres, removing the :
        // and defining the first element as the outcome before discarding
        foreach (var line in lines)
        {
            var numbers = line.Replace(":", "").Split(' ').Select(BigInteger.Parse).ToList();

            BigInteger outcome = numbers[0];

            numbers.RemoveAt(0);

            // Call method to find valid lines
            if (FindMatch(numbers, outcome))
            {
                totalCounter += outcome;
            }
        }

        // Display total counter
        Console.WriteLine($"Total Counter: {totalCounter}");

        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} milliseconds.");
    }


    // Method that goes trough all possible positions of + , * and ||, comparing each possibility to the outcome integer
    // If they are the same, add to the total counter
    private static bool FindMatch(List<BigInteger> numbers, BigInteger outcome)
    {
        int n = numbers.Count;
        int possibilities = (int)Math.Pow(3, n - 1); 

        return Enumerable.Range(0, possibilities)
            .AsParallel()
            .Any(i =>
            {
                BigInteger result = numbers[0];
                for (int k = 0; k < n - 1; k++)
                {
                    int operatorChoice = (i / (int)Math.Pow(3, k)) % 3;

                    switch (operatorChoice)
                    {
                        case 0: 
                            result += numbers[k + 1];
                            break;
                        case 1: 
                            result *= numbers[k + 1];
                            break;
                        case 2:
                            result = BigInteger.Parse(result.ToString() + numbers[k + 1].ToString());
                            break;
                    }
                }
                return result == outcome;
            });
    }
}
