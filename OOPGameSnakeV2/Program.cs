using NConsoleGraphics;
using System;

namespace OOPGameSnakeV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 70;     //Window width in columns
            Console.WindowHeight = 44;    //Window height in rows
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.Title = "Snake The Game";
            //Console.BackgroundColor = ConsoleColor.Gray;
            //Console.CursorVisible = false;
            //Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();
            Console.WriteLine($"Console.WindowWidth {Console.WindowWidth}");
            Console.WriteLine($"graphics.ClientWidth {graphics.ClientWidth}");
            Console.WriteLine($"Console.WindowHeight {Console.WindowHeight}");
            Console.WriteLine($"graphics.ClientHeight {graphics.ClientHeight}");
            Console.WriteLine($"relative Height {graphics.ClientHeight / Console.WindowHeight}");
            Console.WriteLine($"relative Width {graphics.ClientWidth / Console.WindowWidth}");
            Console.WindowWidth = 69;     //Window width in columns
            Console.WindowHeight = 43;    //Window height in rows
            Console.WriteLine($"Console.WindowWidth {Console.WindowWidth}");
            Console.WriteLine($"graphics.ClientWidth {graphics.ClientWidth}");
            Console.WriteLine($"Console.WindowHeight {Console.WindowHeight}");
            Console.WriteLine($"graphics.ClientHeight {graphics.ClientHeight}");
            //Console.WindowWidth 70
            //graphics.ClientWidth 507
            //Console.WindowHeight 48
            //graphics.ClientHeight 689
            //Console.WindowWidth 69
            //graphics.ClientWidth 483
            //Console.WindowHeight 47
            //graphics.ClientHeight 658
            //GameEngine engine = new GameEngineSnake(graphics);
            //engine.Start();
            Console.ReadLine();
        }
    }
}
