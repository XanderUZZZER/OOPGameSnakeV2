using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class Food : Cell
    {
        Random randomPosition = new Random();
        public int XStart { get; set; }
        public int YStart { get; set; }
        public int XEnd { get; set; }
        public int YEnd { get; set; }
        public bool CanCreateNext { get; set; }

        public Food(int xStart, int yStart, int xEnd, int yEnd, Color color) : base(xStart, yStart, color)
        {
            XStart = xStart;
            YStart = xStart;
            XEnd = xEnd;
            YEnd = yEnd;
            CanCreateNext = true;

            CreateNext();
        }

        public void CreateNext()
        {
            if (CanCreateNext)
            {
                X = randomPosition.Next(0, XEnd / Size - 1) * Size + XStart;
                Y = randomPosition.Next(0, YEnd / Size - 1) * Size + YStart;
            }
            CanCreateNext = false;
        }

        public void Update()
        {
        }
    }
}
