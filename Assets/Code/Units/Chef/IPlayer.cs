using Code.Configs;
using Code.Movement;

namespace Code.Units.Chef
{
    public interface IPlayer
    {
        IMovable Movement { get; }
        IChefConfig Config { get; }
    }
}