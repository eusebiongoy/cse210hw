using System;
using System.Collections.Generic;

// Represents a single comment made on a video
public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    // Constructor to initialize the comment properties
    public Comment(string name, string text)
    {
        CommenterName = name;
        CommentText = text;
    }
}

// Represents a YouTube video
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> _comments; // Use a private list to store comments

    // Constructor to initialize the video properties and the comment list
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthInSeconds = length;
        _comments = new List<Comment>();
    }

    // Method to add a new comment to the video's list
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to get the list of comments (for display purposes)
    public List<Comment> GetComments()
    {
        return _comments;
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // 1. Create a list to hold all videos
        List<Video> videos = new List<Video>();

        // 2. Create and populate Video 1
        Video video1 = new Video("Introduction to C#", "Microsoft Learn", 600);
        video1.AddComment(new Comment("Eleanor", "Great tutorial! Very helpful for beginners."));
        video1.AddComment(new Comment("Bryan", "Clear explanation, but a bit fast at times."));
        video1.AddComment(new Comment("Marcia", "Thanks for the free resource. Loved it."));
        videos.Add(video1);

        // 3. Create and populate Video 2
        Video video2 = new Video("Top 10 Programming Languages 2026", "TechGuru", 1200);
        video2.AddComment(new Comment("David", "Python should be higher on the list!"));
        video2.AddComment(new Comment("Eve", "Glad to see Rust getting recognition."));
        video2.AddComment(new Comment("Frank", "Interesting insights, author knows their stuff."));
        video2.AddComment(new Comment("Grace", "Where is Java? Disappointed."));
        videos.Add(video2);

        // 4. Create and populate Video 3
        Video video3 = new Video("Cooking an Italian Dish", "Chef John", 900);
        video3.AddComment(new Comment("Heidi", "My family loved this recipe. Simple and delicious."));
        video3.AddComment(new Comment("Ivan", "Followed the instructions exactly, perfect results."));
        videos.Add(video3);

        // 5. Iterate through the list of videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            // Use the method to get the comment count
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            // List out all comments for the video
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: \"{comment.CommentText}\"");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
    }
}
