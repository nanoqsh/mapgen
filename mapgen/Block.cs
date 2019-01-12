
using System;


namespace mapgen
{
    class Block
    {
        // Doors:
        public bool Top;
        public bool Bottom;
        public bool Left;
        public bool Right;

        public bool StartBlock;

        // Position of the block
        public readonly Point Position;

        public Block(int x, int y)
        {
            Top = false;
            Bottom = false;
            Left = false;
            Right = false;

            Position = new Point(x, y);
        }

        // Make a door in the direction
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
