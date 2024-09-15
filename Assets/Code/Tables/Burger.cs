using System;
using UnityEngine;

namespace Code.Tables
{
    public class Burger: MonoBehaviour
    {
        public bool IsActive => gameObject.activeSelf;

        public void HideBurger()
        {
            gameObject.SetActive(false);
            Debug.Log("hide burger");
        }
        
        public void ShowBurger()
        {
            gameObject.SetActive(true);
            Debug.Log("show burger");
        }

    }
}