using UnityEngine;

namespace Code.Tables
{
    public class Table : MonoBehaviour, ITable
    {
        [SerializeField] private Burger _burger;
        
        public bool HasBurger => _burger.IsActive;

        public void Clear() => 
            _burger.HideBurger();

        public void Add()
        {
            if (HasBurger) 
                return;
            _burger.ShowBurger();
        }
    }
}