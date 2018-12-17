using System;
using System.Collections.Generic;

namespace mapgen
{
    class Generator
    {
        private int width;
        private int height;
        private Block[,] blocks;
        private List<Block> nonEmptyBlocks;

        public Generator(int width, int height)
        {
            this.width = width;
            this.height = height;

            nonEmptyBlocks = new List<Block>();

            // Create map
            blocks = new Block[width, height];
        }

        public void Generate(int numOfBlocks)
        {
            if (numOfBlocks > width * height)
                throw new ArgumentException("Too many blocks!");
            
            if (numOfBlocks <= 0)
                throw new ArgumentException("Too few blocks!");

            int plan = numOfBlocks;

            // Create start block in a random place
            Block startBlock = CreateRandomBlock();
            plan--;

            startBlock.StartBlock = true;

            while (plan != 0)
            {
                if (BuildNextBlock(GetRandomNonEmptyBlock(), DirectionExtension.GetRandomDirection()))
                    plan--;
            }
        }

        public List<Block> GetGeneratedMap()
        {
            return nonEmptyBlocks;
        }

        private bool BuildNextBlock(Block parent, Direction direction)
        {
            // Get position of new block
            Point point = GetNearPoint(parent.Position, direction);

            // Check is the point inside the map
            if (!CheckBorder(point))
                return false;

            // Take a block and make a door
            parent.MakeDoor(direction);

            // Get existing block or null
            Block block = GetBlock(point);

            // Check block
            if (block == null)
            {
                CreateBlock(point).MakeDoor(direction.GetOpposite());

                // If we created a block will return a true
                return true;
            }

            block.MakeDoor(direction.GetOpposite());

            // If we didn't create a block will return a false
            return false;
        }

        private Point GetNearPoint(Point position, Direction direction)
        {
            int x = position.X;
            int y = position.Y;

            switch (direction)
            {
                case Direction.Top:
                    return new Point(x, y + 1);

                case Direction.Bottom:
                    return new Point(x, y - 1);

                case Direction.Left:
                    return new Point(x - 1, y);

                case Direction.Right:
                    return new Point(x + 1, y);

                default:
                    throw new Exception("Wrong direction!");
            }
        }

        // Get block by position
        // If block isn't created returns null
        private Block GetBlock(Point position)
        {
            return blocks[position.X, position.Y];
        }

        // This method checks is the point inside the map
        private bool CheckBorder(Point position)
        {
            return
                   position.X < width
                && position.X >= 0
                && position.Y < height
                && position.Y >= 0;
        }

        private Block CreateBlock(Point position)
        {
            // Create new block
            Block block = new Block(position.X, position.Y);

            // Add new block on the map
            blocks[position.X, position.Y] = block;
            nonEmptyBlocks.Add(block);

            // Return created block
            return block;
        }

        // This method returns random created block
        private Block GetRandomNonEmptyBlock()
        {
            return nonEmptyBlocks[new Random().Next(0, nonEmptyBlocks.Count)];
        }

        // This method creates a block in random place
        private Block CreateRandomBlock()
        {
            Random rand = new Random();
            int x = rand.Next(0, width);
            int y = rand.Next(0, height);
            
            return CreateBlock(new Point(x, y));
        }
    }
}
