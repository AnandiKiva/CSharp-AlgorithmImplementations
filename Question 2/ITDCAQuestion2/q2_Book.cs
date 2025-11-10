namespace ITDCAQuestion2
{
    public class q2_Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public q2_Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }
    }
}
