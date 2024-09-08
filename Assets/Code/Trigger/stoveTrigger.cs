using Code.Tables;
using UnityEngine;

namespace Code.Trigger
{
    public class StoveTrigger: MonoBehaviour
    {

        [SerializeField]private Table _table;
        [SerializeField]private BoxCollider _collider;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("stove trigger activate");
            _table.Clear();
        }

        private void OnDrawGizmos()
        {
            if (!_collider) return;

            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }
    }
}