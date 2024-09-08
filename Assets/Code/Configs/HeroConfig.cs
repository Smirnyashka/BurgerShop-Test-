using UnityEngine;
using Zenject;

namespace Code.Configs
{
    public class HeroConfig
    {
        private float _speed = 15f;

        public float Speed => _speed;
    }
}