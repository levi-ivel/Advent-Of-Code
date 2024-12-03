// To see puzzle description, see README

// Time complexity: O(
// Execution time:  miliseconds

using System;
using System.Diagnostics;

class Day4Part1_2024
{
    public static void ExecuteDay4Part1()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Define and read input
        string day4Input = "Solutions/2024/Day4/Inputs/Day4Input.txt";

        string[] inputData = File.ReadAllLines(day4Input);


        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }

}