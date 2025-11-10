using System;

namespace ITDCAQuestion2
{
    class Program
    {
        static void Main(string[] args)
        {
            q2_AVLTree avlTree = new q2_AVLTree();

            //Sample Data
            avlTree.Insert(new q2_Book("The Silent Patient", "Alex Michaelides", 2019));
            avlTree.Insert(new q2_Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));
            avlTree.Insert(new q2_Book("To Kill a Mockingbird", "Harper Lee", 1960));
            avlTree.Insert(new q2_Book("1984", "George Orwell", 1949));
            avlTree.Insert(new q2_Book("The Catcher in the Rye", "J.D. Salinger", 1951));
            avlTree.Insert(new q2_Book("Pride and Prejudice", "Jane Austen", 1813));
            avlTree.Insert(new q2_Book("Moby-Dick", "Herman Melville", 1851));
            avlTree.Insert(new q2_Book("The Hobbit", "J.R.R. Tolkien", 1937));
            avlTree.Insert(new q2_Book("Brave New World", "Aldous Huxley", 1932));
            avlTree.Insert(new q2_Book("The Book Thief", "Markus Zusak", 2005));

            //In-order traversal
            Console.WriteLine("Books in-order (by year):");
            avlTree.InOrderTraversal(avlTree.Root);

            //Search by year
            Console.WriteLine("\nSearching for a book from 1960:");
            Console.WriteLine(avlTree.SearchByYear(1960) ? "Found!" : "Not found");

            //Most recent book
            var recent = avlTree.GetMostRecentBook();
            Console.WriteLine($"\nMost recent book: {recent.Title} by {recent.Author} ({recent.Year})");

            //Total number of books
            Console.WriteLine($"\nTotal books in tree: {avlTree.CountBooks(avlTree.Root)}");

            Console.ReadLine();
        }
    }
}

