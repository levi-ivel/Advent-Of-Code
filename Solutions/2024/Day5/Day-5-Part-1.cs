// To see puzzle description, see README

// Time complexity: O(n * m), where n is the amount of rows and m the amount of columns
// Execution time: varies between 3 and 34 miliseconds

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

class Day5Part1_2024
{
    public static void ExecuteDay5Part1()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        

        // Define, read and change input into a grid
        string day4Input = "Solutions/2024/Day4/Inputs/Day4Input.txt";

        string[] lines = File.ReadAllLines(day4Input);


        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} milliseconds.");
    }
}