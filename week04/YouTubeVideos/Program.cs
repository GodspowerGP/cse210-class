using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video();
        video1._title = "How to learn C#";
        video1._author = "Code Master";
        video1._length = 600;

        Comment v1Comment1 = new Comment();
        v1Comment1._name = "John";
        v1Comment1._text = "Great video!";
        video1._comments.Add(v1Comment1);

        Comment v1Comment2 = new Comment();
        v1Comment2._name = "Mary";
        v1Comment2._text = "Very helpful, thanks.";
        video1._comments.Add(v1Comment2);

        Comment v1Comment3 = new Comment();
        v1Comment3._name = "Bob";
        v1Comment3._text = "I still don't understand classes.";
        video1._comments.Add(v1Comment3);

        videos.Add(video1);

        Video video2 = new Video();
        video2._title = "Top 10 Programming Languages";
        video2._author = "Tech Guru";
        video2._length = 900;

        Comment v2Comment1 = new Comment();
        v2Comment1._name = "Alice";
        v2Comment1._text = "Python is the best!";
        video2._comments.Add(v2Comment1);

        Comment v2Comment2 = new Comment();
        v2Comment2._name = "Charlie";
        v2Comment2._text = "What about Java?";
        video2._comments.Add(v2Comment2);

        Comment v2Comment3 = new Comment();
        v2Comment3._name = "Dave";
        v2Comment3._text = "Nice list.";
        video2._comments.Add(v2Comment3);

        videos.Add(video2);

        Video video3 = new Video();
        video3._title = "Funny Cats Compilation";
        video3._author = "Cat Lover";
        video3._length = 300;

        Comment v3Comment1 = new Comment();
        v3Comment1._name = "Eve";
        v3Comment1._text = "So cute!";
        video3._comments.Add(v3Comment1);

        Comment v3Comment2 = new Comment();
        v3Comment2._name = "Frank";
        v3Comment2._text = "The second cat is hilarious.";
        video3._comments.Add(v3Comment2);

        Comment v3Comment3 = new Comment();
        v3Comment3._name = "Grace";
        v3Comment3._text = "I love cats.";
        video3._comments.Add(v3Comment3);

        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }
            
            Console.WriteLine();
        }
    }
}