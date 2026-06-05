using System;
using System.Collections.Generic;
using System.IO;

// Exceeding Requirements:
// 1. I added a file logging system. Every time you finish an activity, it writes the stats to "mindfulness_log.txt".
// 2. I added a menu option (number 4) to show statistics like total sessions, total seconds, and how many times you did each activity.
// 3. I made sure that prompts and questions are not repeated in a session until all of them are used.

class Program
{
    private static readonly string LogFile = "mindfulness_log.txt";

    static void Main(string[] args)
    {
        BreathingActivity breathing = new BreathingActivity();
        ReflectionActivity reflection = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View Activity Log / Statistics");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    breathing.Run();
                    LogActivity(breathing.GetName(), breathing.GetDuration());
                    break;
                case "2":
                    reflection.Run();
                    LogActivity(reflection.GetName(), reflection.GetDuration());
                    break;
                case "3":
                    listing.Run();
                    LogActivity(listing.GetName(), listing.GetDuration());
                    break;
                case "4":
                    DisplayStatistics();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a option between 1 and 5.");
                    Console.Write("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void LogActivity(string name, int duration)
    {
        try
        {
            string logLine = $"{name}|{duration}|{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            File.AppendAllText(LogFile, logLine + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not write to log file: {ex.Message}");
        }
    }

    private static void DisplayStatistics()
    {
        Console.Clear();
        Console.WriteLine("=== Mindfulness Activity Log & Statistics ===");
        Console.WriteLine();

        if (!File.Exists(LogFile))
        {
            Console.WriteLine("No activities logged yet. Start doing some mindfulness exercises!");
            Console.WriteLine();
            Console.Write("Press enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(LogFile);
            int totalSessions = 0;
            int totalDuration = 0;
            
            Dictionary<string, int> countPerActivity = new Dictionary<string, int>();
            Dictionary<string, int> durationPerActivity = new Dictionary<string, int>();
            List<string> historyList = new List<string>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int duration = int.Parse(parts[1]);
                    string timestamp = parts[2];

                    totalSessions++;
                    totalDuration += duration;

                    if (!countPerActivity.ContainsKey(name))
                    {
                        countPerActivity[name] = 0;
                        durationPerActivity[name] = 0;
                    }

                    countPerActivity[name]++;
                    durationPerActivity[name] += duration;

                    historyList.Add($"[{timestamp}] {name} - {duration} seconds");
                }
            }

            Console.WriteLine($"Total Sessions Completed: {totalSessions}");
            Console.WriteLine($"Total Mindfulness Time : {totalDuration} seconds");
            Console.WriteLine();

            Console.WriteLine("Breakdown by Activity:");
            foreach (var kvp in countPerActivity)
            {
                string name = kvp.Key;
                int count = kvp.Value;
                int duration = durationPerActivity[name];
                Console.WriteLine($" - {name}: {count} session(s), totaling {duration} seconds");
            }
            Console.WriteLine();

            Console.WriteLine("Recent Activity History (Up to last 5):");
            int historyToShow = Math.Min(5, historyList.Count);
            for (int i = historyList.Count - 1; i >= historyList.Count - historyToShow; i--)
            {
                Console.WriteLine($"  {historyList[i]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading statistics: {ex.Message}");
        }

        Console.WriteLine();
        Console.Write("Press enter to return to the menu...");
        Console.ReadLine();
    }
}