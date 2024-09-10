using System;
using UniRx;
using UnityEngine;

namespace Code.Movement
{
    
    [RequireComponent(typeof(CharacterController))]
    
    public class PlayerMobileMovement: MonoBehaviour, IMovable
    {
        [SerializeField] private Transform _model;
        [SerializeField] private CharacterController _controller;
        
        private ReactiveProperty<bool> _isMoving = new();
        public IReactiveProperty<bool> IsMoving => _isMoving;

        private void Start()
        {
           transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        public void Move(Vector3 direction, float speed)
        {
            if (CheckMovementState(direction)) return;

            _model.LookAt(_model.position + direction);
            _controller.Move(-direction * speed * Time.deltaTime);
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