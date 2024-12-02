﻿// To see puzzle description, see README

// Time complexity: O(n log n)
// Space complexity: O(n)

using System;
using System.Collections.Generic;

class Day1Part1_2024
{
    public static void ExecuteDay1Part1()
    {
        // Define input data 
        string day1Input = "Solutions/2024/Day1/Inputs/Day1Input.txt";


        // Define lists for the left and right numbers
        List<int> leftNumbers = new List<int>();
        List<int> rightNumbers = new List<int>();

        try
        {
            // Read input
            string[] lines = File.ReadAllLines(day1Input);

            foreach (string line in lines)
            {
                // Parse into 2 lists (first number goes left, second goes right, etc.)
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int left) &&
                    int.TryParse(parts[1], out int right))
                {
                    leftNumbers.Add(left);
                    rightNumbers.Add(right);
                }
                else
                {
                    Console.WriteLine($"Invalid input line: {line}");
                }
            }

            // Sort lists using built-in sorting
            leftNumbers.Sort();
            rightNumbers.Sort();

            // Define the final number of all distances added together
            int finalNumber = 0;

            // Subtract the first from the second number, ignoring the - for negative numbers
            for (int i = 0; i < leftNumbers.Count; i++)
            {
                int distance = Math.Abs(rightNumbers[i] - leftNumbers[i]);

                // Displays distance for a given pair
                Console.WriteLine($"Distance {i + 1}: {distance}");

                finalNumber += distance;
            }

            // Displays all distances added up
            Console.WriteLine($"Final Number: {finalNumber}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The file 'Day1Input.txt' was not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
