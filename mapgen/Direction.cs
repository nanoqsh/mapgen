
using System;


namespace mapgen
{
    enum Direction
    {
        Top, Bottom, Right, Left
    }

    static class DirectionExtension
    {
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
