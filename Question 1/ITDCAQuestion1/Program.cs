using System;

namespace ITDCAQuestion1
{
    class Program
    {
        static void Main()
        {
            q1_AVLTree tree = new q1_AVLTree();

            q1_Book[] books = new q1_Book[]
            {
                new q1_Book("The Silent Patient", "Alex Michaelides", 2019),
                new q1_Book("The Great Gatsby", "F. Scott Fitzgerald", 1925),
                new q1_Book("To Kill a Mockingbird", "Harper Lee", 1960),
                new q1_Book("1984", "George Orwell", 1949),
                new q1_Book("The Hobbit", "J.R.R. Tolkien", 1937)
            };

            foreach (var book in books)
                tree.Insert(book);

            Console.WriteLine("AVL Tree created successfully!");
        }
    }
}
