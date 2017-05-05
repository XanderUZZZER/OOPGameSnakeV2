using System.Collections.Generic;
using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class Snake : IGameObject
    {
        List<Cell> body = new List<Cell>(3);
        //int x = Background.WidthActive / 2;                           //Snake tail start position
        //int y = Background.HeightActive / 2;
        Color color = Color.Black;

        public Snake()
        {
            //body.Add(new Cell(x, y, color));
            //body.Add(new Cell(x, y + Cell.Size, color));
            //body.Add(new Cell(x, y + Cell.Size * 2, color));
        }
        public void Render(ConsoleGraphics graphics)
        {
            foreach (Cell c in body)
            {
                c.Render(graphics);
            }
        }

        public void Update(GameEngine engine)
        {
        }
    }
}
