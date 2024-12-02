using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        // Ask for year, day and part
        Console.WriteLine("Enter the year (2024 to 2024):");
        string? year = Console.ReadLine();

        Console.WriteLine("Enter the day (1 to 2):");
        string? day = Console.ReadLine();

        Console.WriteLine("Enter the part (1 to 2):");
        string? part = Console.ReadLine();

        try
        {
            // Define class and method name using the users input
            string className = $"Day{day}Part{part}_{year}";
            string methodName = $"ExecuteDay{day}Part{part}";

            Assembly? assembly = Assembly.GetExecutingAssembly();

            // Try to get class and method, and execute said method
            Type? type = assembly.GetType(className);
            if (type == null)
            {
                Console.WriteLine($"The class '{className}' does not exist.");
                return;
            }

            MethodInfo? method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            if (method == null)
            {
                Console.WriteLine($"The methods '{methodName}' does not exist.");
                return;
            }

            method.Invoke(null, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
