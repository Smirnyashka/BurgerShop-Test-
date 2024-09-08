using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Services.InputService
{
    public class MobileInput : MonoBehaviour
    {
        private Vector2 _moveDirection;
        public float _moveSpeed = 5f;

        public void InputPlayer(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }


        private void ReadInput(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }

        public void Update()
        {
            Vector3 movement = new Vector3(_moveDirection.x, 0, _moveDirection.y);
            movement.Normalize();
            transform.Translate(_moveSpeed * movement * Time.deltaTime);
        }
    }
}
