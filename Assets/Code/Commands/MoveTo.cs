using System;
using Code.Units.Clients;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Commands
{
    public class MoveTo : ICommand
    {
        private IClient _client;
        private Transform _point;
        private float _duration;

        public MoveTo(IClient client, Transform point, float duration)
        {
            _client = client;
            _point = point;
            _duration = duration;
        }

        public void Execute()
        {
            Debug.Log($"Move to - {_point.position}");
            if (_point == null) throw new NullReferenceException(nameof(_point));
            _client.Movable.Move(_point.position, _duration);
        }
    }
}