using UnityEngine;

namespace Code.Interfeces
{
    public class CubeMovement : IMovement
    {
        private readonly Transform _transform;
        private readonly Vector2 _center;
        private readonly Vector2 _offset;

        public CubeMovement(Transform transform, Vector2 center, Vector2 offset)
        {
            _transform = transform;
            _center = center;
            _offset = offset;
        }
        
        public Vector2 Move(float speed, Vector2 direction)
        {
            Vector2 newPosition = _transform.position;

            Debug.Log(_offset);
            
            var normalized = (_center - newPosition + _offset).normalized;

            newPosition += (speed * normalized * Time.deltaTime);
            return newPosition;
        }
    }
}