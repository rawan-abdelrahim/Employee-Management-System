using System;

namespace Employee_Management_System
{
    public static class InputService
    {
        public static T GetValidInput<T>(string prompt, Func<string, T> validator, int maxAttempts = 3)
        {
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                try
                {
                    T result = validator(input);
                    return result;
                }
                catch (Exception ex)
                {
                    attempts++;
                    Console.WriteLine($"Error: {ex.Message}");
                    if (attempts < maxAttempts)
                    {
                        Console.WriteLine("Please try again.\n");
                    }
                    else
                    {
                        Console.WriteLine("Too many invalid attempts. Ending program.");
                        Console.WriteLine("\nPress any key to exit...");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                }
            }
            return default;
        }
    }
}
