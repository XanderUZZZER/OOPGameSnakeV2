using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class Cell
    {
        public static readonly int Size = 34;   // determines the size and grid of the playing field and game objects
        public int X { get; set; }              // top left coords of the cell
        public int Y { get; set; }
        //public int XMax { get; set; }
        //public int YMax { get; set; }
        //public int Offset { get; set; }
        public Color Color { get; protected set; }

        public Cell()
        {
        }

        public Cell(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        //public Cell(int x, int y, int xMax, int yMax, int offset, Color color)
        //{
        //    X = x;
        //    Y = y;
        //    Offset = offset;
        //    XMax = xMax + offset;
        //    YMax = yMax + offset;
        //    Color = color;
        //}

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle((uint)Color, X + 4, Y + 4, 26, 26, 4); // outer rect 30x30, outer margin 2px, inner margin 4 px, thickness 4px
            graphics.FillRectangle((uint)Color, X + 10, Y + 10, 14, 14);  // inner filled rect 14x14 px
        }
    }
}
