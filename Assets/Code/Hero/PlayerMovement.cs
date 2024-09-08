using System;
using Code.Configs;
using Code.Services.InputService;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Hero
{
    public class PlayerMovement: MonoBehaviour, IMovable
    {
        [SerializeField] private Transform _model;
        [SerializeField] private CharacterController _controller;
        
        private ReactiveProperty<bool> _isMoving = new();
        public IReactiveProperty<bool> IsMoving => _isMoving;

        private HeroConfig _config;
        private Vector3 _moveDirection;

        [Inject]
        public void Construct(HeroConfig config)
        {
            _config = config;
        }

        public void Move(Vector3 direction)
        { 
            if (CheckMovementState(direction)) return;

            _model.LookAt(_model.position + direction);
            _controller.Move(direction * _config.Speed * Time.deltaTime);
        }

        private bool CheckMovementState(Vector3 direction)
        {
            bool isMove = direction.magnitude != 0;

            if (_isMoving.Value != isMove)
                _isMoving.Value = isMove;

            return IsMoving.Value == false;
        }
    }
}