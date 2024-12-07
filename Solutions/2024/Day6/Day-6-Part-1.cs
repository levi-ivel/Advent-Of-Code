// To see puzzle description, see README

// Time complexity: O(n * m ^ 2), where n is the amount of rows and m is the amount of columns
// Execution time: 384 miliseconds (yikes! will be optimized later)

using System;
using System.Diagnostics;

class Day6Part1_2024
{
    public static void ExecuteDay6Part1()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Define, read and change input into grid
        string day6Input = "Solutions/2024/Day6/Inputs/Day6Input.txt";

        string[] lines = File.ReadAllLines(day6Input);
        char[][] grid = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = lines[i].ToCharArray();
        }

        // Define the total counter and hash set for all unique positions
        // Total counter is set to 1 to account for the last unique position
        int totalCounter = 1;
        HashSet<(int, int)> markedPositions = new HashSet<(int, int)>();

        // Get the grid and check for the following:
        // If arrow has a . infront of it, move to the direction the arrow is facing, add one to the total counter and mark it's previous position
        // If arrow has a # infront of it, change into an arrow that has moved 90 degrees
        // If nothing is infront of it, display the total counter
        bool isGridUpdated = true;
        while (isGridUpdated)
        {
            isGridUpdated = false; 
            char[][] newGrid = CopyGrid(grid);

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    char current = grid[row][col];

                    switch (current)
                    {
                        case '^': 
                            if (row > 0 && grid[row - 1][col] == '.')
                            {
                                if (markedPositions.Add((row, col))) 
                                {
                                    totalCounter++;
                                }
                                newGrid[row - 1][col] = '^';
                                newGrid[row][col] = '.';
                                isGridUpdated = true;
                            }
                            else if (row > 0 && grid[row - 1][col] == '#')
                            {
                                newGrid[row][col] = '>';
                                isGridUpdated = true;
                            }
                            break;

                        case '>':
                            if (col < grid[row].Length - 1 && grid[row][col + 1] == '.')
                            {
                                if (markedPositions.Add((row, col))) 
                                {
                                    totalCounter++;
                                }
                                newGrid[row][col + 1] = '>';
                                newGrid[row][col] = '.';
                                isGridUpdated = true;
                            }
                            else if (col < grid[row].Length - 1 && grid[row][col + 1] == '#')
                            {
                                newGrid[row][col] = 'v';
                                isGridUpdated = true;
                            }
                            break;

                        case 'v': 
                            if (row < grid.Length - 1 && grid[row + 1][col] == '.')
                            {
                                if (markedPositions.Add((row, col))) 
                                {
                                    totalCounter++;
                                }
                                newGrid[row + 1][col] = 'v';
                                newGrid[row][col] = '.';
                                isGridUpdated = true;
                            }
                            else if (row < grid.Length - 1 && grid[row + 1][col] == '#')
                            {
                                newGrid[row][col] = '<';
                                isGridUpdated = true;
                            }
                            break;

                        case '<': 
                            if (col > 0 && grid[row][col - 1] == '.')
                            {
                                if (markedPositions.Add((row, col))) 
                                {
                                    totalCounter++;
                                }
                                newGrid[row][col - 1] = '<';
                                newGrid[row][col] = '.';
                                isGridUpdated = true;
                            }
                            else if (col > 0 && grid[row][col - 1] == '#')
                            {
                                newGrid[row][col] = '^';
                                isGridUpdated = true;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            grid = newGrid;
        }

        // Display total counter
        Console.WriteLine($"Total unique positions marked: {totalCounter}");

        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} milliseconds.");
    }

    // Copies the grid
    private static char[][] CopyGrid(char[][] grid)
    {
        char[][] newGrid = new char[grid.Length][];
        for (int i = 0; i < grid.Length; i++)
        {
            newGrid[i] = (char[])grid[i].Clone();
        }
        return newGrid;
    }
}
