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

        public Food(int x, int y, int xMax, int yMax, int offset, Color color) : base(x, y, xMax, yMax, offset, color)
        {
        }

        public void CreateNext()
        {
            X = randomPosition.Next(0, XMax/Size - 1) * Size + Offset;
            Y = randomPosition.Next(0, YMax/Size - 1) * Size + Offset;
            //X = (XMax / Size - 1) * Size + Offset;
            //Y = (YMax / Size - 1) * Size + Offset;
        }

        public void Update()
        {
            if (Input.IsKeyDown(Keys.UP))
            {
                CreateNext();
                if (Color == Color.Red)
                    Color = Color.Green;
                else
                    Color = Color.Red;
            }
                
        }
    }
}
