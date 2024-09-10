using UnityEngine;

namespace Code.Services.InputService
{
    public interface IInput
    {
        void Enable();
        void Disable();
        
        public Vector3 Direction { get; }
    }
}