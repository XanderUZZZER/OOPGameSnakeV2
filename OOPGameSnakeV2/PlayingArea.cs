using System;
using System.Collections.Generic;
using System.Linq;
using NConsoleGraphics;
using System.IO;

namespace OOPGameSnakeV2
{
    class PlayingArea : IGameObject
    {
        //Object shows all active objects in playing field
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }
        Background background;
        Snake snake;
        Food food;

        public static int Score = 0;
        public static List<int> TopTen = new List<int>();

        public PlayingArea()
        {
            background = new Background();
            Width = background.WidthActive;
            Height = background.HeightActive;
            X = background.X;
            Y = background.Y;

            StartNewGame();
        }

        void StartNewGame()
        {
            background = new Background();
            snake = new Snake(X, Y, Width, Height);
            food = new Food(X, Y, Width, Height, Color.Red);
            LoadTopTen();
        }

        void LoadTopTen()
        {
            if (!File.Exists("SnakeTopTen.txt"))
            {
                // Create an empty file to write to.
                string[] tempText = new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                File.WriteAllLines("SnakeTopTen.txt", tempText);
                for (int i = 0; i < 10; i++)
                {
                    TopTen.Add(Convert.ToInt32(tempText[i]));
                }
            }
            else
            {
                TopTen.Clear();
                string[] tempText = File.ReadAllLines("SnakeTopTen.txt");
                for (int i = 0; i < 10; i++)
                {
                    TopTen.Add(Convert.ToInt32(tempText[i]));
                }
            }
        }

        void UpdateTopTenFile()
        {
            string[] tempText = new string[TopTen.Count];
            for (int i = 0; i < TopTen.Count; i++)
            {
                tempText[i] = TopTen[i].ToString();
            }
            File.WriteAllLines("SnakeTopTen.txt", tempText);
        }

        public void Render(ConsoleGraphics graphics)
        {
            background.Render(graphics);
            snake.Render(graphics);
            food.Render(graphics);
        }

        public void Update(GameEngine engine)
        {
            snake.Update(engine);
            snake.Eat(food);
            Score = snake.FoodEated * 10;
            snake.HitItself();
            if (snake.HitItself())
            {
                for (int i = 0; i < TopTen.Count; i++)
                {
                    if (Score > TopTen[i])
                    {
                        TopTen.Insert(i, Score);
                        TopTen.Remove(TopTen.Last());
                        break;
                    }
                }

                UpdateTopTenFile();
                StartNewGame();
            }
        }
    }
}
;