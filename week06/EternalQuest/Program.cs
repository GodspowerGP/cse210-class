using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // I have added a gamification "leveling and ranking" system. 
        // Based on the user's total score, they achieve different ranks.
        // For example:
        // Score < 1000 = Novice
        // Score >= 1000 = Apprentice
        // Score >= 3000 = Expert
        // Score >= 5000 = Master
        // The level is dynamically calculated as (score / 1000) + 1.
        // This is displayed in the DisplayPlayerInfo method in GoalManager.cs.

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}