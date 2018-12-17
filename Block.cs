
using System;


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

        public void MakeDoor(Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    Top = true;
                    return;

                case Direction.Bottom:
                    Bottom = true;
                    return;

                case Direction.Left:
                    Left = true;
                    return;

                case Direction.Right:
                    Right = true;
                    return;

                default:
                    throw new Exception("Wrong direction!");
            }
        }
    }
}
