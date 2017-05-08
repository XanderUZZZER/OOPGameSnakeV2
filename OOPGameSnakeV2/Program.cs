using NConsoleGraphics;
using System;

namespace OOPGameSnakeV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 70;     //Window width in columns
            Console.WindowHeight = 48;    //Window height in rows
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
