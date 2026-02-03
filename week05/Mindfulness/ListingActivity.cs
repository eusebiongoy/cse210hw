// ListingActivity.cs
using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }
        }
        return responses;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        DisplayPrompt();
        Console.WriteLine();

        Console.Write($"You have {_duration} seconds to list items. Start now...");

        List<string> userResponses = GetListFromUser();

        Console.WriteLine($"You listed {userResponses.Count} items.");
        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
    }
}
