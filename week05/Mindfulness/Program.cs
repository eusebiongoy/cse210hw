// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Press any key to return to menu.");
                    Console.ReadKey();
                    continue;
            }

            if (activity != null)
            {
                activity.Run();
            }
        }
    }
}
