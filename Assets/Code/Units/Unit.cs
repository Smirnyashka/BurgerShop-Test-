using UnityEngine;

namespace Code.Units
{
    public class Unit : MonoBehaviour, IDamageable
    {
        private IDamageable _health;
        
        
        public void TakeDamage() => _health.TakeDamage();
    }

    public interface IDamageable
    {
        void TakeDamage();
    }

    class Health : IDamageable
    {
        [SerializeField] private float _value;
        [SerializeField] private float _regenerationAtSecond;

        public void TakeDamage()
        {
                        
        }
    }
}
