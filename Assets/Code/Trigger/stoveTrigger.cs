using Code.Commands;
using Code.Tables;
using Code.Units.Chef;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Trigger
{
    public class StoveTrigger : MonoBehaviour, ITrigger
    {
        [SerializeField] private Table _table;
        [SerializeField] private BoxCollider _trigger;

        private IPlayer _chef;

        public void OnTriggerEnter(Collider other)
        {
            _chef = other.GetComponent<Chef>();
            
            if(_table.HasBurger == false || _chef.HasBurger) 
                return;

            ICommand command = new MoveBurgerToChef(_chef, _table);
            _chef.Do(command, _chef.Config.BurgerCookingSpeed);
        }

        public void OnTriggerExit(Collider other)
        {
            _chef.ResetTask();
        }

        private void OnDrawGizmos()
        {
            if (!_trigger) return;

            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + _trigger.center, _trigger.size);
        }
    }
}