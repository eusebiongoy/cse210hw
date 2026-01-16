
using System;

public class Entry
{
    public string DateCreated { get; }
    public string Content { get; }

    //Initializes the date and content of an entry from user input
    public Entry(string dateInput, string content)
    {
        DateCreated = dateInput;
        Content = content;
    }

    //Displays the content of an entry
    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {DateCreated}");
        Console.WriteLine($"Content: {Content}\n");
    }

}
