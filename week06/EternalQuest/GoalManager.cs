using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new();
    private int _score = 0;

    // Random number generator for random events
    private Random _rand = new Random();

    // Streak tracking using goal index
    private Dictionary<int, int> _streaks = new();

    // Achievements tracking
    private HashSet<string> _achievements = new();

    // ==========================
    // Score & Level
    // ==========================
    public void DisplayScore()
    {
        Console.WriteLine($"\nCurrent Score: {_score} | Level: {GetLevel()}\n");
    }

    private int GetLevel()
    {
        return (_score / 500) + 1; // Level 1 at 0-499, Level 2 at 500, etc.
    }

    // ==========================
    // Goal Management
    // ==========================
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        int index = choice - 1;
        Goal goal = _goals[index];

        // Record goal event
        int pointsEarned = goal.RecordEvent();

        // Add streak bonus
        pointsEarned += GetStreakBonus(index);

        // Add random bonus
        pointsEarned += RandomEvent();

        // Check for achievements
        CheckAchievements(goal);

        // Update score
        _score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");
    }

    public void SaveGoals(string filename)
    {
        using StreamWriter writer = new(filename);
        writer.WriteLine(_score);

        foreach (Goal goal in _goals)
        {
            writer.WriteLine(goal.GetSaveString());
        }

        Console.WriteLine($"\n💾 Goals saved to {filename}\n");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("❌ File not found!");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        Console.WriteLine($"\n📂 Loaded file: {filename}");
        Console.WriteLine("================================");
        Console.WriteLine("Saved goals and their status:");

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string goalType = parts[0];
            Goal loadedGoal = null;

            switch (goalType)
            {
                case "Simple":
                    loadedGoal = new SimpleGoal(
                        parts[1],            // name
                        parts[2],            // description
                        int.Parse(parts[3]), // points
                        bool.Parse(parts[4]) // isComplete
                    );
                    break;

                case "Eternal":
                    loadedGoal = new EternalGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])
                    );
                    break;

                case "Checklist":
                    loadedGoal = new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]), // points
                        int.Parse(parts[5]), // target count
                        int.Parse(parts[4]), // bonus
                        int.Parse(parts[6])  // current count
                    );
                    break;
            }

            if (loadedGoal != null)
            {
                _goals.Add(loadedGoal);
                Console.WriteLine($"{i}. {loadedGoal.GetDisplayString()}");
            }
        }

        Console.WriteLine("================================\n");
    }

    // ==========================
    // GAMIFICATION HELPERS
    // ==========================

    // Random event: 10% chance for bonus points
    private int RandomEvent()
    {
        int roll = _rand.Next(1, 11); // 1 to 10
        if (roll == 1)
        {
            Console.WriteLine("\n🎉 Lucky day! You found a hidden treasure! +50 bonus points!");
            return 50;
        }
        return 0;
    }

    // Streak bonus every 3 consecutive completions
    private int GetStreakBonus(int goalIndex)
    {
        if (!_streaks.ContainsKey(goalIndex)) _streaks[goalIndex] = 0;
        _streaks[goalIndex]++;
        if (_streaks[goalIndex] % 3 == 0)
        {
            Console.WriteLine("\n🔥 Streak bonus! +20 points!");
            return 20;
        }
        return 0;
    }

    // Achievements and milestone bonuses
    private void CheckAchievements(Goal goal)
    {
        // First goal completed
        if (!_achievements.Contains("FirstGoal") && goal.IsComplete())
        {
            _achievements.Add("FirstGoal");
            Console.WriteLine("\n🏆 Achievement unlocked: First Goal Completed! +50 bonus points!");
            _score += 50;
        }

        // Checklist master achievement
        if (!_achievements.Contains("ChecklistMaster") && goal is ChecklistGoal cGoal && cGoal.IsComplete())
        {
            _achievements.Add("ChecklistMaster");
            Console.WriteLine("\n🔥 Achievement unlocked: Checklist Master! +100 bonus points!");
            _score += 100;
        }
    }
}
