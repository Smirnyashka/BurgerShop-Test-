using Code.Hero;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Code.Services.InputService
{
    public class SimpleInput: MonoBehaviour
    {
        private IMovable _movable;
        private IAttackble _attackble;
        private GameInput _gameInput;

        [Inject]
        public void Construct(IMovable movable, IAttackble attackble, GameInput gameInput)
        {
            _movable = movable;
            _attackble = attackble;
            _gameInput = gameInput;
            _gameInput.Enable();
        }

        public void Update() => ReadInput();

        private void OnEnable() => 
            _gameInput.GamePlay.Attack.performed += OnAttackPerformed;

        private void OnDisable() => 
            _gameInput.GamePlay.Attack.performed -= OnAttackPerformed;

        private void OnAttackPerformed(InputAction.CallbackContext obj) => 
            _attackble.Attack();


        private void ReadInput()
        {
            var inputDirection = _gameInput.GamePlay.Movement.ReadValue<Vector3>();
            var direction = new Vector3(inputDirection.x, 0f, inputDirection.y);

            _movable.Move(direction);
        }
    }
}