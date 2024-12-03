// To see puzzle description, see README

// Time complexity: O(n * m), where n is the amount of lines and m is the amount of regex matches
// Execution time: 15 miliseconds

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

class Day3Part1_2024
{
    public static void ExecuteDay3Part1()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Define and read input
        string day3Input = "Solutions/2024/Day3/Inputs/Day3Input.txt";

        string[] inputData = File.ReadAllLines(day3Input);

        // Define the total counter
        int totalCounter = 0;

        // Defines regex pattern for mul(int,int)
        string pattern = @"mul\((-?\d+),(-?\d+)\)";

        // If mul(int,int) is found, multiply the integers and add the result to the total counter
        foreach (string line in inputData)
        {
            MatchCollection matches = Regex.Matches(line, pattern);

            foreach (Match match in matches)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                totalCounter += x * y;
            }
        }

        // Display the total counter
        Console.WriteLine($"Total Counter: {totalCounter}");

        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
