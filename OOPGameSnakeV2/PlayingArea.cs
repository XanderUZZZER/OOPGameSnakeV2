using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;
using System.IO;

namespace OOPGameSnakeV2
{
    class PlayingArea : IGameObject
    {
        public static int Width { get; set; }        //  the size of the active playing area, excluding thikcness of the border,
        public static int Height { get; set; }       //  the size of the area depends on the size and number of cells

        public static int X { get; set; }           // top left coords of the cell
        public static int Y { get; set; }

        Background background;
        Snake snake;
        Food food;

        public static int Score = 0;
        public static List<int> TopTen = new List<int>();
        private string[] tempText;

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
                // Create a file to write to.
                tempText = new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                File.WriteAllLines("SnakeTopTen.txt", tempText);
            }
            else
            {
                TopTen.Clear();
                tempText = File.ReadAllLines("SnakeTopTen.txt");
                for (int i = 0; i < 10; i++)
                {
                    TopTen.Add(Convert.ToInt32(tempText[i]));
                }
            }
        }

        void UpdateTopTenFile()
        {
            tempText = File.ReadAllLines("SnakeTopTen.txt");
            for (int i = 0; i < TopTen.Count; i++)
            {
                tempText[i] = TopTen[i].ToString();
            }
            File.WriteAllLines("SnakeTopTen.txt", tempText);
        }


        void ShowInfo(ConsoleGraphics graphics)
        {
            graphics.DrawString("PlayingArea.X: " + X.ToString(), "Consolas", (uint)Color.Blue, 0, 40);
            graphics.DrawString("PlayingArea.Y: " + Y.ToString(), "Consolas", (uint)Color.Blue, 0, 70);
            graphics.DrawString("background.X: " + background.X.ToString(), "Consolas", (uint)Color.Blue, 0, 100);
            graphics.DrawString("Background.Y: " + background.Y.ToString(), "Consolas", (uint)Color.Blue, 0, 130);
            graphics.DrawString("Food.X: " + food.X.ToString(), "Consolas", (uint)Color.Blue, 0, 160);
            graphics.DrawString("Food.Y: " + food.Y.ToString(), "Consolas", (uint)Color.Blue, 0, 190);
            graphics.DrawString("PlayingArea.W: " + Width.ToString(), "Consolas", (uint)Color.Blue, 0, 210);
            graphics.DrawString("PlayingArea.H: " + Height.ToString(), "Consolas", (uint)Color.Blue, 0, 240);
            graphics.DrawString("Background.WidActive: " + background.WidthActive.ToString(), "Consolas", (uint)Color.Blue, 0, 270);
            graphics.DrawString("PlayingArea.HiActive: " + background.HeightActive.ToString(), "Consolas", (uint)Color.Blue, 0, 300);
            graphics.DrawString("Food XEnd: " + food.XEnd.ToString(), "Consolas", (uint)Color.Blue, 0, 330);
            graphics.DrawString("Food YEnd: " + food.YEnd.ToString(), "Consolas", (uint)Color.Blue, 0, 360);
        }

        public void Render(ConsoleGraphics graphics)
        {
            background.Render(graphics);
            //ShowInfo(graphics);
            snake.Render(graphics);
            food.Render(graphics);
        }

        public void Update(GameEngine engine)
        {
            snake.Update(engine);
            snake.Eat(food);
            food.Update();
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