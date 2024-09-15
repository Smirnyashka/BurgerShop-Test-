using System;
using UniRx;
using UnityEngine;

namespace Code.Services.WalletService
{
    public class Wallet: IWallet
    {
        private readonly ReactiveProperty<int> _coins = new(128);
        public IReactiveProperty<int> Coins => _coins;

        public void AddMoney(int addValue)
        {
            if (_coins.Value < 0) 
                _coins.Value = 0;
            
            if (addValue <= 0) 
                throw new ArgumentException(nameof(addValue));

            _coins.Value += addValue;
        }

        public bool TryPayMoney(int value)
        {
            if (_coins.Value < 0)
                _coins.Value = 0;

            if (value <= 0) 
                throw new ArgumentException(nameof(value));

            if (_coins.Value <= value)
            {
                Debug.Log("нет бабок долбаеб");
                return false;
            }

            _coins.Value -= value;
            return true;
        }
    }
}