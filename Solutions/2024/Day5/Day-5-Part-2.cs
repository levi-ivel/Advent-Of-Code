// To see puzzle description, see README

// Time complexity: O(n * m ^ 2), where n is the amount of ordering rules and m the amount of updates
// Execution time: 17 miliseconds

using System;
using System.Diagnostics;

class Day5Part2_2024
{
    public static void ExecuteDay5Part2()
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
            for (int ruleIndex = 0; ruleIndex < updateLists.Count; ruleIndex++)
            {
                // Define the list of an update line, if the list passes the rules 
                // and if the list has been modified
                var ruleList = updateLists[ruleIndex];
                bool rulePassed = false;
                bool isListModified = false;  

                while (!rulePassed)
                {
                    rulePassed = true;  

                    // Go trough each pair, a pair is the same index from the left and right list
                    for (int i = 0; i < leftList.Count; i++)
                    {
                        int leftValue = leftList[i];
                        int rightValue = rightList[i];
                        int leftIndex = ruleList.IndexOf(leftValue);
                        int rightIndex = ruleList.IndexOf(rightValue);

                        // If one of the integers from the pair is not present, skip pai
                        if (leftIndex == -1 || rightIndex == -1)
                        {
                            continue;
                        }

                        // If the right number of the pair appears earlier then the left, fail the list
                        // and modify it by moving the left integer to a position before the right integer
                        if (leftIndex >= rightIndex)
                        {
                            rulePassed = false;

                            ruleList.RemoveAt(leftIndex);
                            ruleList.Insert(rightIndex, leftValue);

                            isListModified = true;
                        }
                    }
                }

                // If the list was not failed, add the value of the middle index's integer to the couner
                if (isListModified)
                {
                    int middleIndex = ruleList.Count / 2;
                    int middleValue = ruleList[middleIndex];
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
