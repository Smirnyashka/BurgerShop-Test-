using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Code.Tables
{
    public class Table: MonoBehaviour,ITable
    {
        private Burger _burger;
        
        private void Awake()
        {
            _burger = GetComponentInChildren<Burger>();
        }


        public void Clear()
        {
            if (_burger == null)
            {
                throw new NullReferenceException(nameof(_burger));
            }
            
            _burger.HideBurger();
            
        }

        public void AddBurger()
        {
            
        }
    }
}