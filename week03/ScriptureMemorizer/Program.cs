using System;
using System.Collections.Generic;
using System.Linq;

//In this program we are going to use different classes to organize our program as required, one for the
// scripture, one for the reference, in addition this we will use other systems to perform our program
// such as system.Collections.Generic and system (Linq to help filter words that are not yet hidden)

class Program
{
    static void Main()
    {

        Scripture scripture = new Scripture("Moroni 10: 3-5", "3 Behold, I would exhort you that when ye shall read these things, if it be wisdom in God that ye would remember how merciful the Lord hath been unto the children of men, from the creation of Adam even down until the time that ye shall receive these things, and ponder in your hearts. 4 And when ye shall receive these things, I would exhort you that yee would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. 5 And by the power of the Holy Ghost ye may know the truth of all things ");


        Console.Clear();
        scripture.DisplayScripture();


        while (true)
        {
            Console.WriteLine("Press enter to hide a word or type quit to exit:");
            string userInput = Console.ReadLine();


            if (userInput.ToLower() == "quit")
            {
                break;
            }
            else
            {

                Console.Clear();
                scripture.HideWord();
                scripture.DisplayScripture();


                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("Congratulations, you have memorized the scripture!");
                    break;
                }
            }
        }
    }
}

class Scripture
{
    private string reference;
    private string text;
    private List<string> hiddenWords;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.hiddenWords = new List<string>();
    }

    public void DisplayScripture()
    {

        Console.WriteLine(reference);
        string[] words = text.Split(' ');
        foreach (string word in words)
        {

            if (hiddenWords.Contains(word))
            {
                Console.Write("_____ ");
            }
            else
            {
                Console.Write(word + " ");
            }
        }
        Console.WriteLine();
    }

    public void HideWord()
    {

        string[] words = text.Split(' ');
        Random rand = new Random();
        int index = rand.Next(words.Length);
        string wordToHide = words[index];


        hiddenWords.Add(wordToHide);
    }

    public bool AllWordsHidden()
    {

        string[] words = text.Split(' ');
        return hiddenWords.Count == words.Length;
    }
}