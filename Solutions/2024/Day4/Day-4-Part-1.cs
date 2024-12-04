// To see puzzle description, see README

// Time complexity: O(n * m), where n is the amount of rows and m the amount of columns
// Execution time: varies between 3 and 34 miliseconds

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

class Day4Part1_2024
{
    public static void ExecuteDay4Part1()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        

        // Define, read and change input into a grid
        string day4Input = "Solutions/2024/Day4/Inputs/Day4Input.txt";

        string[] lines = File.ReadAllLines(day4Input);
        int rows = lines.Length;
        int cols = lines[0].Length;
        char[,] grid = new char[rows, cols];

        for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = lines[i][j];
                }
            }

        // Define string to search and call method to search it
        string word = "XMAS";
        int totalCounter = SearchXMASWords(grid, word);

        // Display the total counter
        Console.WriteLine($"Total Counter: {totalCounter}");

        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} milliseconds.");
    }

    static int SearchXMASWords(char[,] grid, string word)
    {
        // Define the rows, columns, lenght of the word and the total count
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        int wordLength = word.Length;
        int count = 0;

        // Define all 8 directions
        int[] dRow = {-1, -1, -1, 0, 1, 1, 1, 0};
        int[] dCol = {-1, 0, 1, 1, 1, 0, -1, -1};

        // Go trough the entire grid, checking all directions for a matching XMAS
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                 // Check in all directions
                for (int dir = 0; dir < 8; dir++)
                {
                    int newRow = row;
                    int newCol = col;
                    int matchCount = 0;

                    for (int k = 0; k < wordLength; k++)
                    {
                        if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow, newCol] == word[k])
                        {
                            matchCount++;
                            newRow += dRow[dir];
                            newCol += dCol[dir];
                        }
                        else
                        {
                            break;
                        }
                    }

                    // If found, add to the total counter
                    if (matchCount == wordLength)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }   
}