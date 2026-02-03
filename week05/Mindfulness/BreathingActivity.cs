// BreathingActivity.cs
using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("\n\nBreath in...");
            ShowCountDown(4);
            Console.Write("\nBreath out...");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}
