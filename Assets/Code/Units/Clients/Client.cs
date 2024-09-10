using System;
using System.Windows.Input;
using Code.Movement;
using Code.Services.InputService;
using UnityEngine;
using UnityEngine.AI;
using ICommand = Code.Commands.ICommand;

namespace Code.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    class Client : MonoBehaviour, IClient
    {
        public IMovable movable { get; }
        public Transform Transform { get; }

        public void Do(ICommand command, Action onDo = null)
        {
            command.Execute();
        }
    }
}