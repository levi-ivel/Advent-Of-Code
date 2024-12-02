// To see puzzle description, see README

// Time complexity: O(

using System;
using System.Collections.Generic;
using System.Diagnostics;

class Day3Part1_2024
{
    public static void ExecuteDay3Part1()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string day3Input = "Solutions/2024/Day3/Inputs/Day3Input.txt";
        string[] inputData = File.ReadAllLines(day3Input);


        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}