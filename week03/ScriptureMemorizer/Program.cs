using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

//We are going to make up a memorizer scripture that help to memorize a scripture, 
//we are going to use different classes for our program to be displayed according to the given condition.
// one class will be for word, the other for scripture and the one for the running program.
// beside classes we will use different system for the better performance of our program.

class Word
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public string GetDisplayText()
    {
        // Replace letters/digits with underscores of the same length
        return IsHidden ? Regex.Replace(Text, "[a-zA-Z0-9]", "_") : Text;
    }
}

class Scripture
{
    private List<Word> _words;
    private string _reference;
    private Random _random = new Random(); // Use a single instance of Random

    public Scripture(string reference, string text)
    {
        _reference = reference;
        // Simple split, consider more advanced parsing for punctuation if needed
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.Write($"{_reference} ");
        foreach (var word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count = 3) // Hide a few words at a time
    {
        var wordsToHide = _words.Where(word => !word.IsHidden).ToList();

        if (wordsToHide.Count == 0) return;

        // Ensure we don't try to hide more words than available
        int actualCount = Math.Min(count, wordsToHide.Count);

        // Randomly select indices of non-hidden words to hide
        var indicesToHide = Enumerable.Range(0, wordsToHide.Count)
                                      .OrderBy(x => _random.Next())
                                      .Take(actualCount)
                                      .ToList();

        foreach (var index in indicesToHide)
        {
            // Find the original word object and set its status to hidden
            // Note: This needs a better way to map back to the original list if using a filtered list
            // The better way is to work with the original list's indices directly or use a specific tracking mechanism

            // A more direct (though slightly less efficient if very large) way is:
            var nonHiddenWords = _words.Where(w => !w.IsHidden).ToList();
            if (nonHiddenWords.Any())
            {
                nonHiddenWords[_random.Next(nonHiddenWords.Count)].IsHidden = true;
            }
        }
    }

    // A better approach for the HideRandomWords method would involve using the main _words list indices:

    public void HideWordsByIndices(int count = 3)
    {
        var nonHiddenIndices = _words
            .Select((word, index) => new { Word = word, Index = index })
            .Where(item => !item.Word.IsHidden)
            .Select(item => item.Index)
            .ToList();

        if (nonHiddenIndices.Count == 0) return;

        int actualCount = Math.Min(count, nonHiddenIndices.Count);
        var indicesToHide = nonHiddenIndices.OrderBy(x => _random.Next()).Take(actualCount).ToList();

        foreach (var index in indicesToHide)
        {
            _words[index].IsHidden = true;
        }
    }


    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden);
    }
}

// In your Main method:
class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("D&C 18:14-15", "Wherefore you are called to cry repentance unto this people. And if it so be that you should labor all your days in crying repentance unto this people, and bring, save it be one soul unto me, how great shall be your joy with in the kingdom of my Father!.");

        while (!scripture.IsCompletelyHidden())
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else
            {
                scripture.HideWordsByIndices(3); // Hide 3 random words
            }
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.Clear();
            Console.WriteLine("Congratulations, all words are hidden! You have memorized the scripture.");
        }
    }
}
