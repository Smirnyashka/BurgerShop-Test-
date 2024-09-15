using System;
using Code.Tables;
using UnityEngine;

namespace Code.Units.Chef
{
    public class HandBurgerView : MonoBehaviour
    {
        [SerializeField] private Burger _burger;
        private IPlayer _chef;
        private Table _table;

        private void Awake()
        {
            _chef = GetComponent<Chef>();
            _table = GetComponent<Table>();
        }

        private void Start() =>
            _burger.HideBurger();

        private void Update() =>
            ValidateBurgerView();

        private void ValidateBurgerView()
        {
            if (_chef.HasBurger)
                _burger.ShowBurger();
            else
                _burger.HideBurger();
        }
        
    }
}