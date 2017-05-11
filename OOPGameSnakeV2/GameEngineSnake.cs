using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class GameEngineSnake : GameEngine
    {
        private Background background;
        private Food food;
        private Snake snake;
        private PlayingArea playingArea;
        private StatArea statArea;

        public GameEngineSnake(ConsoleGraphics graphics) : base(graphics)
        {
            background = new Background();
            food = new Food(background.X, background.Y, background.WidthActive, background.HeightActive, Color.Red);
            snake = new Snake(background.X, background.Y, background.WidthActive, background.HeightActive);
            //playingArea = new PlayingArea(background, snake, food);
            statArea = new StatArea(PlayingArea.Width, 0, graphics.ClientWidth - PlayingArea.Width, PlayingArea.Height, snake);

            AddObject(background);
            background.Initialize(this);

            AddObject(snake);
            snake.Initialize(this); 
            
            AddObject(food);
           // AddObject(playingArea);            
            AddObject(statArea);
        }
    }
}
