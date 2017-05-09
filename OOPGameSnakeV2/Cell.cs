using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class Cell
    {
        public static readonly int Size = 34;   // minimal element of the game, determines playing grid, playing  field
        public int X { get; set; }              // top left coords of the cell
        public int Y { get; set; }
        public Color Color { get; set; }

        public Cell()
        {
        }

        public Cell(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle((uint)Color, X + 4, Y + 4, 26, 26, 4); // outer rect 30x30, thickness 4px, outer margin 2px, inner margin 4 px
            graphics.FillRectangle((uint)Color, X + 10, Y + 10, 14, 14);  // inner filled rect 14x14 px
        }
    }
}
