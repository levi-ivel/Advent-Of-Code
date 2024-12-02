// To see puzzle description, see README

// Time complexity: O(n)
// Space complexity: O(n)

using System;
using System.Collections.Generic;

class Day1Part2_2024
{
    public static void ExecuteDay1Part2()
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

        // Define a dictionary for the right numbers
        Dictionary<int, int> rightOccurrences = new Dictionary<int, int>();

        foreach (int rightNumber in rightNumbers)
        {
            if (rightOccurrences.ContainsKey(rightNumber))
            {
                rightOccurrences[rightNumber]++;
            }
            else
            {
                rightOccurrences[rightNumber] = 1;
            }
        }

        // Calculate the final number by checking the occurrences in the dictionary
        int finalNumber = 0;
        foreach (int leftNumber in leftNumbers)
        {
            if (rightOccurrences.ContainsKey(leftNumber))
            {
                finalNumber += leftNumber * rightOccurrences[leftNumber];
            }
        }

        // Displays all similarities added up
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
