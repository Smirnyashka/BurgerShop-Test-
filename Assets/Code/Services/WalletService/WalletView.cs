using System;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Code.Services.WalletService
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private IWallet _wallet;

        [Inject]
        private void Construct(IWallet wallet)
        {
            _wallet = wallet;

            if (_wallet == null)
                throw new NullReferenceException(nameof(_wallet));

            _wallet.Coins
                .Subscribe(OnValueChanged)
                .AddTo(_disposable);
        }

        private void OnValueChanged(int value)
        {
            _counter.text = $"{value}";
        }
        
        

        private void OnDisable() => 
            _disposable.Dispose();
    }
}