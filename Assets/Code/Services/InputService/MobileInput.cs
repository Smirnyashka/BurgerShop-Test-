using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Code.Services.InputService
{
    public class MobileInput : MonoBehaviour
    {
        private IMovable _movable;
        private Vector2 _inputDirection;

        [Inject]
        public void Contruct(IMovable movable)
        {
            _movable = movable;
        }
        
        public void ReadInput(InputAction.CallbackContext context) =>
            _inputDirection = context.ReadValue<Vector2>();

        private void ReadDirection()
        {
            Vector3 direction = new Vector3(_inputDirection.x, 0, _inputDirection.y);
            direction.Normalize();
            
            _movable.Move(direction);
        }

        private void Update() =>
            ReadDirection();
    }
}