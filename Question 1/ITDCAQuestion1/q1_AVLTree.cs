using System;
using System.Collections.Generic;

namespace ITDCAQuestion1
{
    public class q1_AVLTree
    {
        public q1_AVLNode Root;

        private int Height(q1_AVLNode node) => node?.Height ?? 0;

        private int GetBalance(q1_AVLNode node)
        {
            if (node == null) return 0;
            return Height(node.Left) - Height(node.Right);
        }

        private q1_AVLNode RotateRight(q1_AVLNode y)
        {
            var x = y.Left;
            var T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        private q1_AVLNode RotateLeft(q1_AVLNode x)
        {
            var y = x.Right;
            var T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        public void Insert(q1_Book book)
        {
            Root = Insert(Root, book);
        }

        private q1_AVLNode Insert(q1_AVLNode node, q1_Book book)
        {
            if (node == null) return new q1_AVLNode(book);

            if (book.Year < node.Data.Year)
                node.Left = Insert(node.Left, book);
            else if (book.Year > node.Data.Year)
                node.Right = Insert(node.Right, book);
            else
                return node; // no duplicates

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            int balance = GetBalance(node);

            // Balancing
            if (balance > 1 && book.Year < node.Left.Data.Year)
                return RotateRight(node);

            if (balance < -1 && book.Year > node.Right.Data.Year)
                return RotateLeft(node);

            if (balance > 1 && book.Year > node.Left.Data.Year)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && book.Year < node.Right.Data.Year)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }
    }
}
