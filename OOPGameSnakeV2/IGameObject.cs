using NConsoleGraphics;

namespace OOPGameSnakeV2
{
    public interface IGameObject
    {
        void Render(ConsoleGraphics graphics);

        void Update(GameEngine engine);
    }
}
