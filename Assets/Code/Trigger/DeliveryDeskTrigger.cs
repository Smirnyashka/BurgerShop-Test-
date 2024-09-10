using System;
using Code.Commands;
using Code.Hero;
using Code.Tables;
using Code.Units.Chef;
using UnityEngine;

namespace Code.Trigger
{
    class DeliveryDeskTrigger : MonoBehaviour, ITrigger
    {
        [SerializeField] private Table _table;
        [SerializeField] private BoxCollider _collider;
        
        private Chef _chef;

        public void OnTriggerEnter(Collider other)
        {
            _chef = other.GetComponent<Chef>();
            if (_chef == null)
                throw new NullReferenceException(nameof(_chef));

            ICommand command = new AddBurgerCommand(_table);

            _chef.Do(command);
        }

        public void OnTriggerExit(Collider other)
        {
            if (_chef.Timer == null)
                throw new NullReferenceException(nameof(_chef.Timer));

            _chef.Timer.Dispose();
        }
    }
}