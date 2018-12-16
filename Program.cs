using System;
using System.Collections.Generic;

namespace mapgen
{
    class Program
    {
        const int WIDTH = 20;
        const int HEIGHT = 5;
        const int NUM_BLOCKS = 25;

        static void ShowMap(List<Block> map)
        {
            Console.WriteLine("\nMap:");

            for (int i = 0; i < WIDTH * 3; i++)
                Console.Write('*');

            int topCursorPosition = Console.CursorTop + HEIGHT * 3;

            foreach (Block block in map)
            {
                Console.SetCursorPosition(block.X * 3, topCursorPosition - block.Y * 3 - 2);
                Console.Write('+');
                Console.Write(block.Top ? ' ' : '-');
                Console.Write('+');

                Console.SetCursorPosition(block.X * 3, topCursorPosition - block.Y * 3 - 1);
                Console.Write(block.Left ? ' ' : '|');
                Console.Write(block.StartBlock ? '.' : ' ');
                Console.Write(block.Right ? ' ' : '|');

                Console.SetCursorPosition(block.X * 3, topCursorPosition - block.Y * 3);
                Console.Write('+');
                Console.Write(block.Bottom ? ' ' : '-');
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
                Console.Write("x: " + block.X + " y: " + block.Y + " sides: ");

                if (block.Top)
                    Console.Write("top ");

                if (block.Bottom)
                    Console.Write("bottom ");

                if (block.Left)
                    Console.Write("left ");

                if (block.Right)
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
