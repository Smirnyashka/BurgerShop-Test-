using Code.Services.WalletService;
using Unity.VisualScripting;
using UnityEditor;

namespace Code.Commands
{
    public class ServeTheClient:ICommand
    {
        private IWallet _wallet;

        public ServeTheClient(IWallet wallet)
        {
            _wallet = wallet;
        }

        public void Execute()
        {
            _wallet.AddMoney(1);
        }
    }
}