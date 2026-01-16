
using System;

public class Journal
{
    public List<Entry> entries;
    public PromptGenerator promptGenerator;

    //Constructor initializes and empty list of entries
    public Journal()
    {
        entries = new List<Entry>();
        //Initializes the prompt generator
        promptGenerator = new PromptGenerator();
    }

    //Adds a new entry to the journal from user input
    public void AddEntry()
    {

        string prompt = promptGenerator.GenerateRandomPrompt();
        Console.Write("Please enter today's date: ");
        string dateInput = Console.ReadLine();
        Console.WriteLine($"Today's Prompt: {prompt}");
        Console.Write("> ");
        string content = Console.ReadLine();
    }

    //Displays data input this session
    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            entry.DisplayEntry();
        }
    }

    //Saves Entries to a file named by the user
    public void SaveToFile()
    {
        Console.Write("Please enter the filename you would like to save to: ");
        string filename = Console.ReadLine();
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine($"{entry.DateCreated}\n{entry.Content}");
                }
            }
            Console.WriteLine($"Journal entries saved to {filename}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving entries to {filename}: {e.Message}");
        }
    }

    //Loads Entries from a file named by the user
    public void LoadFromFile()
    {
        Console.Write("Please enter the file name you would like to load from: ");
        String filename = Console.ReadLine();
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string dateString = reader.ReadLine();
                    string content = reader.ReadLine();
                    Entry entry = new Entry(dateString, content);
                    entries.Add(entry);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading entries from :filename: {e.Message}");
        }
    }

}
