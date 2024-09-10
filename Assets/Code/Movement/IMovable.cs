using UniRx;
using UnityEngine;

namespace Code.Movement
{
    public interface IMovable
    {
        void Move(Vector3 direction, float speed);
        public IReactiveProperty<bool> IsMoving { get; }
    }
}