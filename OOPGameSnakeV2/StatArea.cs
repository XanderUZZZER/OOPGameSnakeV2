using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class StatArea : IGameObject
    {
        public static int Width { get; set; }        //  the size of the active playing area, excluding thikcness of the border,
        public static int Height { get; set; }       //  the size of the area depends on the size and number of cells

        public static int X { get; set; }           // top left coords of the cell
        public static int Y { get; set; }

        private int score = 0;
        private int lastScore = 0;
        private int hiScore = 0;
        

        public StatArea(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawString("Score:", "Consolas", (uint)Color.Black,X + 8, Y, 18);
            graphics.DrawString(score.ToString(), "Consolas", (uint)Color.Black, X + 8, Y + 25, 22);
            graphics.DrawString("Top Ten", "Consolas", (uint)Color.Black, X + 8, Y + 200, 22);
            for (int i = 0; i < PlayingArea.TopTen.Count; i++)
            {
                string temp = "#" + (i + 1).ToString().PadLeft(2) + ": " + PlayingArea.TopTen[i].ToString();
                graphics.DrawString(temp, "Consolas", (uint)Color.Black, X + 8, Y + 226 + i * 26, 22);
            }
            graphics.DrawString("\"Space\" - play", "Consolas", (uint)Color.Black, X + 8, 625, 14);
            graphics.DrawString("\"Esc\" - pause", "Consolas", (uint)Color.Black, X + 8, 650, 14);
        }

        public void Update(GameEngine engine)
        {
            score = PlayingArea.Score;
            //throw new NotImplementedException();
        }
    }
}
