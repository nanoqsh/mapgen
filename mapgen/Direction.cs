
using System;


namespace mapgen
{
    enum Direction
    {
        None   = 0,
        Top    = 1 << 0,
        Bottom = 1 << 1,
        Right  = 1 << 2,
        Left   = 1 << 3
    }

    static class DirectionExtension
    {
        public static bool Contains(this Direction direction, Direction other)
        {
            return (direction & other) == other;
        }

        public static Direction GetOpposite(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    return Direction.Bottom;

                case Direction.Bottom:
                    return Direction.Top;

                case Direction.Left:
                    return Direction.Right;

                case Direction.Right:
                    return Direction.Left;

                default:
                    throw new Exception("Wrong direction!");
            }
        }

        public static Direction GetRandomDirection()
        {
            switch (new Random().Next(0, 4))
            {
                case 0:
                    return Direction.Top;

                case 1:
                    return Direction.Bottom;

                case 2:
                    return Direction.Left;

                case 3:
                    return Direction.Right;

                default:
                    throw new Exception("Wrong direction!");
            }
        }
    }
}
