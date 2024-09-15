using System;
using Code.Commands;
using Code.Configs;
using Code.Movement;

namespace Code.Units.Chef
{
    public interface IPlayer
    {
        event Action<float> TaskStarted;
        event Action TaskEnded;
        public bool HasBurger { get; }

        IMovable Movement { get; }
        IChefConfig Config { get; }

        void Do(ICommand command, float taskTime);
        void ResetTask();
        void PutBurger();
        void TakeBurger();
    }
}