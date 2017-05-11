using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class StatArea : IGameObject
    {
        //Object shows primitive game statistic
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }
        Snake s;
        Food f;
        private GameEngine e;

        public StatArea(int x, int y, int w, int h, Snake s, Food f, GameEngine e)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
            this.s = s;
            this.f = f;
            this.e = e;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawString("Score:", "Consolas", (uint)Color.Black, X + 8, Y, 18);                              //current score
            graphics.DrawString(PlayingArea.Score.ToString(), "Consolas", (uint)Color.Black, X + 8, Y + 25, 22);
            graphics.DrawString("Top Ten", "Consolas", (uint)Color.Black, X + 8, Y + 200, 22);                      //top ten score
            for (int i = 0; i < PlayingArea.TopTen.Count; i++)
            {
                string temp = "#" + (i + 1).ToString().PadLeft(2) + ": " + PlayingArea.TopTen[i].ToString();
                graphics.DrawString(temp, "Consolas", (uint)Color.Black, X + 8, Y + 226 + i * 26, 22);
            }
            graphics.DrawString("\"Space\" - play", "Consolas", (uint)Color.Black, X + 8, 625, 14);                 //playing help
            graphics.DrawString("\"Esc\" - pause", "Consolas", (uint)Color.Black, X + 8, 650, 14);
        }

        public void Update(GameEngine engine)
        {
        }
    }
}
