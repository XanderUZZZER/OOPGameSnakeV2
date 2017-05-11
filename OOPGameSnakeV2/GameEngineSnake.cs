using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class GameEngineSnake : GameEngine
    {
        public GameEngineSnake(ConsoleGraphics graphics) : base(graphics)
        {
            Background background = new Background();
            Snake snake = new Snake(background.X, background.Y, background.WidthActive, background.HeightActive, this);
            Food food = new Food(background.X, background.Y, background.WidthActive, background.HeightActive, Color.Red);
            PlayingArea playingArea = new PlayingArea(background, snake, food);
            StatArea statArea = new StatArea(PlayingArea.Width, 0, graphics.ClientWidth - PlayingArea.Width, PlayingArea.Height, snake, food, this);
            
            AddObject(playingArea);            
            AddObject(statArea);
            AddObject(background);
            background.Initialize(this);
            AddObject(snake);
            snake.Initialize();
            AddObject(food);
        }
    }
}
