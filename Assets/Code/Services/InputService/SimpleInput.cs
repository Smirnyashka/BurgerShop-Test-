using Code.Movement;
using UnityEngine;
using Zenject;

namespace Code.Services.InputService
{
    public class SimpleInput: MonoBehaviour
    {
        private IMovable _movable;
        private GameInput _gameInput;

        [Inject]
        public void Construct(IMovable movable, GameInput gameInput)
        {
            _movable = movable;
            _gameInput = gameInput;
            _gameInput.Enable();
        }

        public void Update() => ReadInput();

        private void ReadInput()
        {
            var inputDirection = _gameInput.GamePlay.Movement.ReadValue<Vector3>();
            var direction = new Vector3(-inputDirection.y, 0f, -inputDirection.x);

            _movable.Move(direction, 5);
        }
    }
}