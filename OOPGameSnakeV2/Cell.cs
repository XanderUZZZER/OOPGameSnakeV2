using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class Cell : IGameObject
    {
        private readonly int size = 34;     // determines the size and grid of the playing field and game objects
        private int x;                      // top left coords of the cell
        private int y;                      // 
        private Color color;

        public Cell(int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle((uint)color, x + 4, y + 4, 26, 26, 4); // outer rect 30x30, outer margin 2px, border 4px
            graphics.FillRectangle((uint)color, x + 10, y + 10, 14, 14);  // inner filled rect 14x14 px, inner margin 4 px
        }

        public void Update(GameEngine engine)
        {
        }
    }
}
