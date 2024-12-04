// To see puzzle description, see README

// Time complexity: O(n * m), where n is the amount of rows and m the amount of columns
// Execution time: varies between 3 and 34 miliseconds

using System;
using System.Diagnostics;

class Day4Part2_2024
{
    public static void ExecuteDay4Part2()
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
        int totalCounter = SearchXMASCross(grid);

        // Display the total counter
        Console.WriteLine($"Total Counter: {totalCounter}");

        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} milliseconds.");
    }


    static int SearchXMASCross(char[,] grid)
    {
        // Define the rows, columns and the total count
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        int count = 0;

        // Go trough the entire grid in 3x3 sections, checking if an A is in the middle and S and M are neighboring diagonals
        for (int row = 1; row < rows - 1; row++)
        {
            for (int col = 1; col < cols - 1; col++)
            {
                if (grid[row, col] == 'A')
                {
                    bool pattern1 = 
                        grid[row-1, col-1] == 'S' &&
                        grid[row-1, col+1] == 'S' &&
                        grid[row+1, col-1] == 'M' &&
                        grid[row+1, col+1] == 'M';

                    bool pattern2 = 
                        grid[row-1, col-1] == 'M' &&
                        grid[row-1, col+1] == 'M' &&
                        grid[row+1, col-1] == 'S' &&
                        grid[row+1, col+1] == 'S';

                    bool pattern3 = 
                        grid[row-1, col-1] == 'M' &&
                        grid[row-1, col+1] == 'S' &&
                        grid[row+1, col-1] == 'M' &&
                        grid[row+1, col+1] == 'S';

                    bool pattern4 = 
                        grid[row-1, col-1] == 'S' &&
                        grid[row-1, col+1] == 'M' &&
                        grid[row+1, col-1] == 'S' &&
                        grid[row+1, col+1] == 'M';

                    // If they match, add to the total counter
                    if (pattern1 || pattern2 || pattern3 || pattern4)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
}