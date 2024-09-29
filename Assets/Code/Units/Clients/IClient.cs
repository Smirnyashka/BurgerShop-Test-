using System;
using Code.Movement;
using UnityEngine;
using UnityEngine.AI;
using ICommand = Code.Commands.ICommand;

namespace Code.Units.Clients
{
    public interface IClient
    {
        void Do(ICommand command, Action onDo = null);
        public IMovable Movable { get; }
        public Transform Transform { get; }

        public NavMeshAgent NavMeshAgent { get; }
    }
}