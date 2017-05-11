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
        private Background background;
        private Snake snake;
        private Food food;
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; } 
        public static int Score = 0;
        public static List<int> TopTen = new List<int>(10);

        public PlayingArea(Background background, Snake snake, Food food)
        {
            this.background = background;
            Width = background.WidthActive;
            Height = background.HeightActive;
            X = background.X;
            Y = background.Y;
            this.snake = snake;
            this.food = food;            
            StartNewGame();
        }

        void StartNewGame()
        {
            LoadTopTen();
            food.CreateNext();
            snake.CreateNewSnake();     
            
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
            for (int i = 0; i < 10; i++)
            {
                tempText[i] = TopTen[i].ToString();
            }
            File.WriteAllLines("SnakeTopTen.txt", tempText);
        }

        public void Render(ConsoleGraphics graphics)
        {
        }

        public void Update(GameEngine engine)
        {
            //if (snake.CanMove)
            //{
            //    snake.Move();            
            //    snake.Eat(food);
            //    snake.HitItself();
            //}
            Score = snake.FoodEated * 10;
            if (snake.IsHit)
            {                
                for (int i = 0; i < 10; i++)
                {
                    if (Score > TopTen[i])
                    {
                        TopTen.Insert(i, Score);
                        TopTen.Remove(TopTen.Last());
                        UpdateTopTenFile();
                        break;
                    }
                }
                
                StartNewGame();
            }
        }
    }
}
;