using System;
using System.Windows.Input;
using Code.Movement;
using Code.Services.InputService;
using UnityEngine;
using ICommand = Code.Commands.ICommand;

namespace Code.Enemy
{
    public interface IClient
    {
        void Do(ICommand command, Action onDo = null);
        public IMovable movable { get; }
        public Transform Transform { get; }
    }
}