using UnityEngine;

namespace Code.Tables
{
    public class Burger: MonoBehaviour
    {
        
        public void HideBurger()
        {
            gameObject.SetActive(false);
        }
        
        public void ShowBurger()
        {
            gameObject.SetActive(true);
        }

    }
}