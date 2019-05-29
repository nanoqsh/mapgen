
using System;


namespace mapgen
{
    class Block
    {
        // Doors:
        public Direction doors;

        public bool StartBlock;

        // Position of the block
        public readonly Point Position;

        public Block(int x, int y)
        {
            doors = Direction.None;
            Position = new Point(x, y);
        }

        // Make a door in the direction
        public void MakeDoor(Direction direction)
        {
            doors |= direction;
        }
    }
}
