using UnityEngine;

namespace Code.Tables
{
    public class Burger: MonoBehaviour
    {
        public bool IsActive => gameObject.activeSelf;

        public void HideBurger() => 
            gameObject.SetActive(false);

        public void ShowBurger() => 
            gameObject.SetActive(true);
    }
}