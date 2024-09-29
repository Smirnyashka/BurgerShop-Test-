using Code.Units.Clients;
using UnityEngine;

namespace Code.Commands
{
    public class MoveToDestination: ICommand
    {
        private IClient _client;
        private Transform _point;
        private float _duration;

        public MoveToDestination(IClient client, Transform point)
        {
            _client = client;
            _point = point;
        }

        public void Execute()
        {
            _client.NavMeshAgent.destination = _point.position;
        }
    }
}