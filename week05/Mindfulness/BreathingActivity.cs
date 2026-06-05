using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int timeElapsed = 0;
        while (timeElapsed < _duration)
        {
            Console.Write("Breathe in...");
            int breatheInTime = Math.Min(4, _duration - timeElapsed);
            ShowCountDown(breatheInTime);
            Console.WriteLine();
            timeElapsed += breatheInTime;

            if (timeElapsed >= _duration)
                break;

            Console.Write("Now breathe out...");
            int breatheOutTime = Math.Min(6, _duration - timeElapsed);
            ShowCountDown(breatheOutTime);
            Console.WriteLine();
            Console.WriteLine();
            timeElapsed += breatheOutTime;
        }

        DisplayEndingMessage();
    }
}
