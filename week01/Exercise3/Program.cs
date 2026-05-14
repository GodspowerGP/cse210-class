using System;

class Program
{
    static void Main()
    {
        string keepPlaying = "yes";
        Random randomGenerator = new Random();

        while (keepPlaying == "yes")
        {
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int count = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                count++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"It took you {count} guesses.");

            Console.Write("Do you want to play again (yes/no)? ");
            keepPlaying = Console.ReadLine();
        }
    }
}