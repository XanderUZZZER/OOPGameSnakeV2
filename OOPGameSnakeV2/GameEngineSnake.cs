using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class GameEngineSnake : GameEngine
    {
        public GameEngineSnake(ConsoleGraphics graphics) : base(graphics)
        {
            AddObject(new PlayingArea());
            AddObject(new StatArea(PlayingArea.Width, 0, graphics.ClientWidth - PlayingArea.Width, PlayingArea.Height));
        }
    }
}
