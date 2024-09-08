using UnityEngine;
using Zenject;

namespace Code.Configs
{
    public class HeroConfig
    {
        private float _speed = 5f;

        public float Speed => _speed;
    }
}