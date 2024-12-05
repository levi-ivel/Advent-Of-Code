// To see puzzle description, see README

// Time complexity: O(n * m), where n is the amount of ordering rules and m the amount of updates
// Execution time: 14 miliseconds

using System;
using System.Diagnostics;

class Day5Part1_2024
{
    public static void ExecuteDay5Part1()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Define and read input
        string day5Input = "Solutions/2024/Day5/Inputs/Day5Input.txt";
        string[] lines = File.ReadAllLines(day5Input);

        // Define lists for the left numbers, right numbers an the update numbers
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        List<List<int>> updateLists = new List<List<int>>();

        // Parse into 2 lists (number before the | goes left, after goes right etc.), 
        // stopping when an empty line is encountered
        bool parsingRules = false;

        foreach (string line in lines)
        {
            if (line.Contains("|"))
            {
                string[] splitLine = line.Split('|');
                leftList.Add(int.Parse(splitLine[0].Trim()));
                rightList.Add(int.Parse(splitLine[1].Trim()));
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                parsingRules = true;
                updateLists.Add(line.Split(',').Select(int.Parse).ToList());
            }
        }

        // Define total counter
        int totalCounter = 0;

        if (parsingRules)
        {
            for (int updateIndex = 0; updateIndex < updateLists.Count; updateIndex++)
            {
                // Define the list of an update line, and if the list passes the rules
                var updateList = updateLists[updateIndex];
                bool rulePassed = true;
                
                // Go trough each pair, a pair is the same index from the left and right list 
                for (int i = 0; i < leftList.Count; i++)
                {
                    int leftValue = leftList[i];
                    int rightValue = rightList[i];
                    int leftIndex = updateList.IndexOf(leftValue);
                    int rightIndex = updateList.IndexOf(rightValue);

                    // If one of the integers from the pair is not present, skip pair
                    if (leftIndex == -1 || rightIndex == -1)
                    {
                        continue;
                    }
                    
                    // If the right number of the pair appears earlier then the left, fail the list
                    if (leftIndex >= rightIndex)
                    {
                        rulePassed = false;
                        break;
                    }
                }

                // If the list was not failed, add the value of the middle index's integer to the couner
                if (rulePassed)
                {
                    int middleIndex = updateList.Count / 2;
                    int middleValue = updateList[middleIndex];
                    totalCounter += middleValue;
                }
            }
        }

        // Display total counter
        Console.WriteLine($"\nTotal counter: {totalCounter}");

        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} milliseconds.");
    }
}
