// To see puzzle description, see README

// Time complexity: O(
// Execution time: miliseconds

using System;
using System.Diagnostics;

class Day6Part1_2024
{
    public static void ExecuteDay6Part1()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Define and read input
        string day6Input = "Solutions/2024/Day6/Inputs/Day6Input.txt";
        string[] lines = File.ReadAllLines(day6Input);

        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} milliseconds.");
    }
}
