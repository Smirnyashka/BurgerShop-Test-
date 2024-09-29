using System;
using Code.Movement;
using UnityEngine;
using UnityEngine.AI;
using ICommand = Code.Commands.ICommand;

namespace Code.Units.Clients
{
    [RequireComponent(typeof(NavMeshAgent))]
    class Client : MonoBehaviour, IClient
    {
        public IMovable Movable { get; private set; }
        public Transform Transform { get; private set; }

        public NavMeshAgent NavMeshAgent { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            Movable = GetComponent<IMovable>();

            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void Do(ICommand command, Action onDo = null)
        {
            command.Execute();
        }
    }
}