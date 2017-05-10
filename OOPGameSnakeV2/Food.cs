using System;

namespace OOPGameSnakeV2
{
    class Food : Cell, IGameObject
    {
        private Random randomPosition = new Random();
        public int XStart { get; set; }         //available top left coords
        public int YStart { get; set; }
        public int XEnd { get; set; }           //available bottom right coords
        public int YEnd { get; set; }
        public bool CanCreateNext { get; set; } //flag enabling creatining next food        

        public Food(int xStart, int yStart, int xEnd, int yEnd, Color color) : base(xStart, yStart, color)
        {
            XStart = xStart;
            YStart = yStart;
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

        public void Update(GameEngine engine)
        {
        }
    }
}
