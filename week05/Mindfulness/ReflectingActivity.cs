// ReflectingActivity.cs
using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you witnessed something extraordinary."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you might not have acted?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you apply this one experience to your future endeavors?"
    };

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    private void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(5);
            Console.WriteLine();
        }
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("\nConsider the following prompt:");
        DisplayPrompt();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        DisplayQuestions();

        DisplayEndingMessage();
    }
}
