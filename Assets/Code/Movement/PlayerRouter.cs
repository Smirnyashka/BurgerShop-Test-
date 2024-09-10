using System;
using Code.Hero;
using Code.Services.InputService;
using Code.Units.Chef;
using UnityEngine;
using Zenject;

namespace Code.Movement
{
    public class PlayerRouter : IFixedTickable
    {
        private readonly IInput _input;
        private readonly IPlayer _player;
        
        public PlayerRouter(IInput input, IPlayer player)
        {
            _input = input;
            _player = player;
        }

        public void FixedTick()
        {
            if (_player == null) throw new NullReferenceException(nameof(_player));
            if (_input == null) throw new NullReferenceException(nameof(_input));
            if (_player.Config == null) throw new NullReferenceException(nameof(_player.Config));

            Rout(_player.Movement, _input.Direction, _player.Config.Speed);
        }

        private void Rout(IMovable movement, Vector3 direction, float speed) => 
            movement.Move(direction, speed);
    }
}