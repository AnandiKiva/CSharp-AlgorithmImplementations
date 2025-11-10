using System;

namespace ITDCAQuestion2
{
    public class q2_AVLTree
    {
        public q2_AVLNode Root;

        private int Height(q2_AVLNode node) => node?.Height ?? 0;

        private int GetBalance(q2_AVLNode node)
        {
            if (node == null) return 0;
            return Height(node.Left) - Height(node.Right);
        }

        private q2_AVLNode RotateRight(q2_AVLNode y)
        {
            var x = y.Left;
            var T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        private q2_AVLNode RotateLeft(q2_AVLNode x)
        {
            var y = x.Right;
            var T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        public void Insert(q2_Book book)
        {
            Root = Insert(Root, book);
        }

        private q2_AVLNode Insert(q2_AVLNode node, q2_Book book)
        {
            if (node == null) return new q2_AVLNode(book);

            if (book.Year < node.Data.Year)
                node.Left = Insert(node.Left, book);
            else if (book.Year > node.Data.Year)
                node.Right = Insert(node.Right, book);
            else
                return node; // Duplicate years not inserted

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = GetBalance(node);

            // Left Left Case
            if (balance > 1 && book.Year < node.Left.Data.Year)
                return RotateRight(node);

            // Right Right Case
            if (balance < -1 && book.Year > node.Right.Data.Year)
                return RotateLeft(node);

            // Left Right Case
            if (balance > 1 && book.Year > node.Left.Data.Year)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right Left Case
            if (balance < -1 && book.Year < node.Right.Data.Year)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        //In-order traversal
        public void InOrderTraversal(q2_AVLNode node)
        {
            if (node == null) return;
            InOrderTraversal(node.Left);
            Console.WriteLine($"{node.Data.Title} by {node.Data.Author} ({node.Data.Year})");
            InOrderTraversal(node.Right);
        }

        //Search by year
        public bool SearchByYear(int year)
        {
            var current = Root;
            while (current != null)
            {
                if (year == current.Data.Year) return true;
                current = (year < current.Data.Year) ? current.Left : current.Right;
            }
            return false;
        }

        //Most recent book
        public q2_Book GetMostRecentBook()
        {
            var current = Root;
            while (current?.Right != null)
                current = current.Right;
            return current?.Data;
        }

        //Count total books
        public int CountBooks(q2_AVLNode node)
        {
            if (node == null) return 0;
            return 1 + CountBooks(node.Left) + CountBooks(node.Right);
        }
    }
}

