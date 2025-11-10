namespace ITDCAQuestion2
{
    public class q2_AVLNode
    {
        public q2_Book Data;
        public q2_AVLNode Left;
        public q2_AVLNode Right;
        public int Height;

        public q2_AVLNode(q2_Book data)
        {
            Data = data;
            Height = 1;
        }
    }
}
