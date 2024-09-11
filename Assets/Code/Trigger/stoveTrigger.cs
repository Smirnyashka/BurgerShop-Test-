using System;
using Code.Commands;
using Code.Hero;
using Code.Tables;
using Code.Units.Chef;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Trigger
{
    public class StoveTrigger : MonoBehaviour, ITrigger
    {
        [SerializeField] private Table _table;
        [SerializeField] private BoxCollider _collider;

        private IPlayer _chef;

        public void OnTriggerEnter(Collider other)
        {
            _chef = other.GetComponent<Chef>();
            if (_chef == null)
                throw new NullReferenceException(nameof(_chef));

            ICommand command = new ClearTableCommand(_table);

            _chef.Do(command);
        }

        public void OnTriggerExit(Collider other)
        {
            _chef.ResetTask();
        }

        private void OnDrawGizmos()
        {
            if (!_collider) return;

            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }
    }
}