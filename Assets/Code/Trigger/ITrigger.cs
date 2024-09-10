using UnityEngine;

namespace Code.Trigger
{
    public interface ITrigger
    {
        void OnTriggerEnter(Collider other);
        void OnTriggerExit(Collider other);

    }
}