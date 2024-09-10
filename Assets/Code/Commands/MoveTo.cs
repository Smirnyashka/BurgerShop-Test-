using System;
using Code.Enemy;
using UnityEngine;

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
            if (_client == null) throw new NullReferenceException(nameof(_client));
            if (_point == null) throw new NullReferenceException(nameof(_point));
            
            _client.movable.Move(_point.position, _duration);
        }
    }
}