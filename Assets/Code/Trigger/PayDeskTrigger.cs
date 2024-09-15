using Code.Commands;
using Code.Services.WalletService;
using Code.Units.Chef;
using UnityEngine;
using Zenject;

namespace Code.Trigger
{
    public class PayDeskTrigger: MonoBehaviour
    {
        private IPlayer _chef;
        private IWallet _wallet;

        [Inject]
        private void Construct(IWallet wallet) => 
            _wallet = wallet;

        private void OnTriggerEnter(Collider other)
        {

            _chef = other.GetComponent<Chef>();
            
            ICommand command = new ServeTheClient(_wallet);
            _chef.Do(command, _chef.Config.CashServiceSpeed);
        }

        private void OnTriggerExit(Collider other) => 
            _chef.ResetTask();
    }
}