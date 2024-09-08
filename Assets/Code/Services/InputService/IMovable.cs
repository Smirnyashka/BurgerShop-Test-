using UniRx;
using UnityEngine;

namespace Code.Services.InputService
{
    public interface IMovable
    {
        void Move(Vector3 direction);
        public IReactiveProperty<bool> IsMoving { get; }
    }
}