using NConsoleGraphics;
using System;
using System.Windows;
using System.Runtime.InteropServices;

namespace OOPGameSnakeV2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Console.LargestWindowHeight == 72) // Full HD == 72  HD Ready == 44
            {
                Console.WindowHeight = 48;    //Window height in rows
            }
            else
            {
                Console.WindowHeight = 44;    //Window height in rows
            }
            Console.WindowWidth = 70;     //Window width in columns
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
