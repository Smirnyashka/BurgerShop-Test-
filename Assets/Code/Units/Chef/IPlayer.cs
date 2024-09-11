using System;
using Code.Commands;
using Code.Configs;
using Code.Movement;

namespace Code.Units.Chef
{
    public interface IPlayer
    {
        event Action OnTaskStarted;
        event Action OnTaskEnded;

        IMovable Movement { get; }
        IChefConfig Config { get; }

        void Do(ICommand command);
        void ResetTask();
    }
}