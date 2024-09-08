using UnityEngine;

namespace Code.Extensions
{
    public class TransformExtension
    {
        public static Vector2 ToVector2(Transform transform)
        {
            var position = transform.position;
            return new Vector2(position.x, position.y);
        }
    }
}