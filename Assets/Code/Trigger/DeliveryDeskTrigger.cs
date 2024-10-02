using Code.Commands;
using Code.Tables;
using Code.Units.Chef;
using UnityEngine;

namespace Code.Trigger
{
    class DeliveryDeskTrigger : MonoBehaviour
    {
        [SerializeField] private Table _table;

        private IPlayer _chef;

        public void OnTriggerEnter(Collider other)
        {
            _chef = other.GetComponent<Chef>();
            
            if (_table.HasBurger || _chef.HasBurger == false) 
                return;

            ICommand command = new MoveBurgerToTable(_chef,_table);
            _chef.Do(command, _chef.Config.BurgerCookingSpeed);
        }

        public void OnTriggerExit(Collider other) => 
            _chef.ResetTask();
    }
}