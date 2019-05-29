using System;
using System.Collections.Generic;

namespace mapgen
{
    class Program
    {
        const int WIDTH = 25;
        const int HEIGHT = 7;
        const int NUM_BLOCKS = 30;

        static void ShowMap(List<Block> map)
        {
            Console.WriteLine("\nMap:");

            for (int i = 0; i < WIDTH * 3; i++)
                Console.Write('*');

            int topCursorPosition = Console.CursorTop + HEIGHT * 3;

            foreach (Block block in map)
            {
                Point position = block.Position;
                Console.SetCursorPosition(position.X * 3, topCursorPosition - position.Y * 3 - 2);
                Console.Write('+');
                Console.Write(block.doors.Contains(Direction.Top) ? ' ' : '-');
                Console.Write('+');

                Console.SetCursorPosition(position.X * 3, topCursorPosition - position.Y * 3 - 1);
                Console.Write(block.doors.Contains(Direction.Left) ? ' ' : '|');
                Console.Write(block.StartBlock ? '.' : ' ');
                Console.Write(block.doors.Contains(Direction.Right) ? ' ' : '|');

                Console.SetCursorPosition(position.X * 3, topCursorPosition - position.Y * 3);
                Console.Write('+');
                Console.Write(block.doors.Contains(Direction.Bottom) ? ' ' : '-');
                Console.Write('+');
            }

            Console.SetCursorPosition(0, topCursorPosition + 1);
            for (int i = 0; i < WIDTH * 3; i++)
                Console.Write('*');
            Console.WriteLine();
        }

        static void ShowBlocks(List<Block> blocks)
        {
            foreach (Block block in blocks)
            {
                Point position = block.Position;
                Console.Write("x: " + position.X + " y: " + position.Y + " doors: ");

                if (block.doors.Contains(Direction.Top))
                    Console.Write("top ");

                if (block.doors.Contains(Direction.Bottom))
                    Console.Write("bottom ");

                if (block.doors.Contains(Direction.Left))
                    Console.Write("left ");

                if (block.doors.Contains(Direction.Right))
                    Console.Write("right ");

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Generator gen = new Generator(WIDTH, HEIGHT);
            gen.Generate(NUM_BLOCKS);

            List<Block> map = gen.GetGeneratedMap();

            ShowBlocks(map);
            ShowMap(map);

            Console.ReadKey();
        }
    }
}
