namespace ITDCAQuestion1
{
    // Represents a single node in the AVL tree
    public class q1_AVLNode
    {
        public q1_Book Data;
        public q1_AVLNode Left;
        public q1_AVLNode Right;
        public int Height;

        public q1_AVLNode(q1_Book data)
        {
            Data = data;
            Height = 1;
        }
    }
}
