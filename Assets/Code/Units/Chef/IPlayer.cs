using System;
using Code.Commands;
using Code.Configs;
using Code.Movement;
using UnityEngine;

namespace Code.Units.Chef
{
    public interface IPlayer
    {
        event Action<float> TaskStarted;
        event Action TaskEnded;
        public bool HasBurger { get; }

        IMovable Movement { get; }
        IChefConfig Config { get; }

        Vector3 Position { get; set; }

        void Do(ICommand command, float taskTime);
        void ResetTask();
        void PutBurger();
        void TakeBurger();
    }
}