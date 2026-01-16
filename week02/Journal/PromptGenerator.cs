
using System;

public class PromptGenerator
{
    public List<string> Prompts { get; set; }

    public PromptGenerator()
    {
        Prompts = new List<string> {
            "What was the best part of your day?",
            "Write about an experience where you felt the spirit with you today:",
            "Who was the most interesting person you interacted with today?",
            "Write about something that happened for which you are grateful today:",
            "If you had one thing you could do over today, what would it be?",
            "What was the strongest emotion you felt today?",
            "Write about an act of service you either witnessed or performed today:>",
            "Write about something you learned today:",
            "Write about a tender mercy you noticed today:",
            "Write about a positive interaction you had with someone else today:",
            "Write about something you noticed that reminded you of Jesus Christ today:",
            "Write about something you learned about someone in your life today:",
            "Write about an experience you had that allowed you to teach someone else today:"
        };
    }

    public string GenerateRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(Prompts.Count);
        return Prompts[index];
    }

}
