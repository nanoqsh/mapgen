
namespace mapgen
{
    class Block
    {
        public bool Empty;

        public bool Top;
        public bool Bottom;
        public bool Left;
        public bool Right;

        public bool StartBlock;

        public readonly int X;
        public readonly int Y;

        public Block(int x, int y)
        {
            Empty = true;

            Top = false;
            Bottom = false;
            Left = false;
            Right = false;

            X = x;
            Y = y;
        }
    }
}
