using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class Background : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int WidthTotal { get; set; }
        public int HeightTotal { get; set; }
        public int WidthActive { get; set; }
        public int HeightActive { get; set; }
        public Color Color { get; set; } = Color.BackgroundColor;
        public int BorderThikcness { get; set; } = 4;
        public Color BorderColor { get; set; } = Color.Black;
        public Cell FillingCell { get; set; }

        public Background()
        {
            WidthActive = Cell.Size * 10;            
            HeightActive = Cell.Size * 20;
            WidthTotal = WidthActive + BorderThikcness * 2;
            HeightTotal = HeightActive + BorderThikcness * 2;
            X = BorderThikcness;
            Y = BorderThikcness;
            FillingCell = new Cell(X, Y, Color.ForegroundColor);
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle((uint)BorderColor, 0, 0, WidthTotal, HeightTotal);                   // Draw border
            graphics.FillRectangle((uint)Color, X, Y, WidthActive, HeightActive);                       // Draw background
            for (FillingCell.Y = Y; FillingCell.Y < HeightActive; FillingCell.Y += Cell.Size)
            {
                for (FillingCell.X = X; FillingCell.X < WidthActive; FillingCell.X += Cell.Size)
                {
                    FillingCell.Render(graphics);                                                       // Draw decorative filling of the background
                }
            }
        }

        public void Update(GameEngine engine)
        {
        }
    }
}
