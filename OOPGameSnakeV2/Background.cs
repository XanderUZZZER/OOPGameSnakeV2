using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class Background : IGameObject
    {
        //Object shows playing field background
        public int X { get; set; }                                  //top left (starting) coords of active playing field
        public int Y { get; set; }
        public int WidthTotal { get; set; }                         //total dimesions including border thickness
        public int HeightTotal { get; set; }
        public int WidthActive { get; set; }                        //dimensions of active playing field (excluding border thickness)
        public int HeightActive { get; set; }                       //classic game field consists of 10*20 cells
        public Color Color { get; set; } = Color.BackgroundColor;
        public int BorderThikcness { get; set; } = 4;
        public Color BorderColor { get; set; } = Color.Black;

        public Background()
        {
            WidthActive = Cell.Size * 10;
            HeightActive = Cell.Size * 20;
            WidthTotal = WidthActive + BorderThikcness * 2;
            HeightTotal = HeightActive + BorderThikcness * 2;
            X = BorderThikcness;
            Y = BorderThikcness;
        }

        public void Initialize(GameEngine engine)
        {
            for (int y = Y; y < HeightActive; y += Cell.Size)
            {
                for (int x = X; x < WidthActive; x += Cell.Size)
                {
                    engine.AddObject(new Cell(x, y, Color.ForegroundColor));   // Draw decorative filling of the background
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle((uint)BorderColor, 0, 0, WidthTotal, HeightTotal);                   // Draw border
            graphics.FillRectangle((uint)Color, X, Y, WidthActive, HeightActive);                       // Draw background

        }

        public void Update(GameEngine engine)
        {

        }
    }
}
