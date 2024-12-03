// To see puzzle description, see README

// Time complexity: O(n), where n is the amount of characters
// Execution time: 27 miliseconds

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

class Day3Part2_2024
{
    public static void ExecuteDay3Part2()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
    
        // Define and read input
        string day3Input = "Solutions/2024/Day3/Inputs/Day3Input.txt";

        string inputData = File.ReadAllText(day3Input);

        // Define the total counter 
        int totalCounter = 0;

        // Define the bool that allows multiplication
        bool isActive = true;

        // Defines regex patterns for mul(int,int), don't(), and do()
        string mulPattern = @"mul\((-?\d+),(-?\d+)\)";
        string dontPattern = @"don't\(\)";
        string doPattern = @"do\(\)";

        string currentText = "";  

        // Go through the input text letter by letter
        for (int i = 0; i < inputData.Length; i++)
        {
            char currentChar = inputData[i];
            currentText += currentChar;


            // If don't() is found, make bool false
            if (Regex.IsMatch(currentText, dontPattern))
            {
                isActive = false;
                currentText = ""; 
                continue;  
            }

            // If do()"is found, make bool true
            if (Regex.IsMatch(currentText, doPattern))
            {
                isActive = true;
                currentText = "";  
                continue;  
            }

            // If mul(int,int) is found and the bool is true, multiply the integers and add the result to the total counter
            if (isActive && Regex.IsMatch(currentText, mulPattern))
            {
                Match match = Regex.Match(currentText, mulPattern);
                if (match.Success)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);
                    totalCounter += x * y;
                }

                currentText = "";  
            }
        }

        // Display the total counter
        Console.WriteLine($"Total Counter: {totalCounter}");

        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
