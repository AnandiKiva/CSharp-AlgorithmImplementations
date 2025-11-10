using System;

namespace ITDCAQuestion1
{
    // Represents a book object
    public class q1_Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public q1_Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} ({Year})";
        }
    }
}

