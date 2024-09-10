using System;
using Code.Hero;
using Code.Trigger;
using UnityEngine;

namespace Code.Tables
{
    public class Table : MonoBehaviour, ITable
    {
        [SerializeField] private Burger _burger;

        /*private void Awake() => 
            _burger = GetComponentInChildren<Burger>();*/

        public void Clear()
        {
            if (_burger == null)
                throw new NullReferenceException(nameof(_burger));

            _burger.HideBurger();
        }

        public void Add()
        {
            if (_burger == null)
                throw new NullReferenceException(nameof(_burger));

            _burger.ShowBurger();
        }
    }
}