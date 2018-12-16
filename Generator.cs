using System;
using System.Collections.Generic;

enum Direction
{
    Top, Bottom, Right, Left
}

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

            // Set coordinates for each block
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    blocks[i, j] = new Block(i, j);
        }

        public void Generate(int numOfBlocks)
        {
            if (numOfBlocks > width * height)
                throw new ArgumentOutOfRangeException("You wanna too many blocks!");

            if (numOfBlocks <= 0)
                throw new ArgumentException("Too few blocks!");

            int plan = numOfBlocks;

            // Create start block in a random place
            Block startBlock = SetRandomBlock();
            plan--;

            startBlock.StartBlock = true;

            while (plan != 0)
            {
                if (BuildNextBlock(GetRandomNonEmptyBlock(), GetRandomDirection()))
                    plan--;
            }
        }

        public List<Block> GetGeneratedMap()
        {
            return nonEmptyBlocks;
        }

        private bool BuildNextBlock(Block parent, Direction direction)
        {
            Block block = GetNearBlock(parent, direction);

            // GetNearBlock returns null if we're trying create
            // a block outside the map

            if (block == null)
                return false;

            // Take a fucking block and make a door
            MakeDoor(parent, direction);

            // Make a block with door
            if (block.Empty)
            {
                MakeDoor(CreateBlock(block), GetOppositeDirection(direction));

                // If we created a block will return a true
                return true;
            }
            else
            {
                MakeDoor(block, GetOppositeDirection(direction));

                // If we didn't create a block will return a false
                return false;
            }
        }

        private Block GetNearBlock(Block block, Direction direction)
        {
            int x = block.X;
            int y = block.Y;

            switch (direction)
            {
                case Direction.Top:
                    y++;
                    break;

                case Direction.Bottom:
                    y--;
                    break;

                case Direction.Left:
                    x--;
                    break;

                case Direction.Right:
                    x++;
                    break;

                default:
                    throw new Exception("Wrong direction!");
            }

            if (x >= width || x < 0 || y >= height || y < 0)
                return null;

            return blocks[x, y];
        }

        private void MakeDoor(Block block, Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    block.Top = true;
                    return;

                case Direction.Bottom:
                    block.Bottom = true;
                    return;

                case Direction.Left:
                    block.Left = true;
                    return;

                case Direction.Right:
                    block.Right = true;
                    return;

                default:
                    throw new Exception("Wrong direction!");
            }
        }

        private Direction GetOppositeDirection(Direction direction)
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

        private Block CreateBlock(int x, int y)
        {
            Block block = blocks[x, y];

            block.Empty = false;
            nonEmptyBlocks.Add(block);

            return block;
        }

        private Block CreateBlock(Block block)
        {
            block.Empty = false;
            nonEmptyBlocks.Add(block);

            return block;
        }

        private Direction GetRandomDirection()
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

        private Block GetRandomNonEmptyBlock()
        {
            return nonEmptyBlocks[new Random().Next(0, nonEmptyBlocks.Count)];
        }

        private Block SetRandomBlock()
        {
            Random rand = new Random();
            int x = rand.Next(0, width);
            int y = rand.Next(0, height);
            
            return CreateBlock(x ,y);
        }
    }
}
