using NConsoleGraphics;
using System;

namespace OOPGameSnakeV2
{
    class Program
    {
        static void Main(string[] args)
        {
            //check client's display resolution
            if (Console.LargestWindowHeight == 72) // max for Full HD == 72,  max for HD Ready == 44
            {
                Console.WindowHeight = 48;
            }
            else
            {
                Console.WindowHeight = 44;
            }
            Console.WindowWidth = 70;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.Title = "Snake The Game";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();
            GameEngine engine = new GameEngineSnake(graphics);
            engine.Start();
        }
    }
}
