using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    class GameEngineSnake : GameEngine
    {
        public GameEngineSnake(ConsoleGraphics graphics) : base(graphics)
        {
            AddObject(new Cell());
        }
    }
}
