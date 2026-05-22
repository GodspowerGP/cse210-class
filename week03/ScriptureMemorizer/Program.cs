using System;
using System.Collections.Generic;
using System.IO;

// EXTRA CREDIT (Exceeding Requirements):
// 1. The program loads a library of scriptures from a text file ("scriptures.txt").
// 2. It randomly selects one of the scriptures from the library to present to the user.
// 3. The HideRandomWords method is smart: it only selects from words that are NOT already hidden (Stretch Challenge).

class Program
{
    static void Main(string[] args)
    {
        // 1. Load the scriptures from the file
        List<Scripture> scripturesLibrary = new List<Scripture>();
        
        // Make sure the file exists before trying to read it
        if (File.Exists("scriptures.txt"))
        {
            string[] lines = File.ReadAllLines("scriptures.txt");
            foreach (string line in lines)
            {
                // Format is: Book|Chapter|StartVerse|EndVerse|Text
                string[] parts = line.Split('|');
                
                if (parts.Length == 5)
                {
                    string book = parts[0];
                    int chapter = int.Parse(parts[1]);
                    int startVerse = int.Parse(parts[2]);
                    int endVerse = int.Parse(parts[3]);
                    string text = parts[4];

                    // Create the reference and scripture objects
                    Reference reference = new Reference(book, chapter, startVerse, endVerse);
                    Scripture scripture = new Scripture(reference, text);
                    
                    // Add it to our library
                    scripturesLibrary.Add(scripture);
                }
            }
        }
        else
        {
            Console.WriteLine("Could not find scriptures.txt file. Please make sure it exists.");
            return;
        }

        // 2. Select a random scripture from the library
        Random random = new Random();
        int randomIndex = random.Next(scripturesLibrary.Count);
        Scripture selectedScripture = scripturesLibrary[randomIndex];

        // 3. Main program loop
        string userInput = "";

        while (userInput != "quit" && !selectedScripture.IsCompletelyHidden())
        {
            // Clear the console screen
            Console.Clear();

            // Display the complete scripture (or partially hidden)
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();

            // Prompt the user
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            if (userInput != "quit")
            {
                // Hide a few random words (e.g., 3 at a time)
                selectedScripture.HideRandomWords(3);
            }
        }

        // When all words are hidden (or user types quit), clear screen one last time
        // if they didn't quit, to show the final hidden state.
        if (selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("You have memorized the scripture!");
        }
        else
        {
             Console.WriteLine("Goodbye!");
        }
    }
}