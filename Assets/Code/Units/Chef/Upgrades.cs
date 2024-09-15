using Code.Configs;
using Code.Services.WalletService;
using UnityEngine;
using Zenject;

namespace Code.Units.Chef
{
    public class Upgrades: MonoBehaviour
    {
        private IUpgradeConfig Config { get; set; }
        private IChefConfig ChefConfig { get; set; }
        private Wallet _wallet;

        private int _price = 1;

        [Inject]
        public void Construct(IChefConfig chefConfig, IUpgradeConfig config, Wallet wallet)
        {
            Config = config;
            ChefConfig = chefConfig;
            _wallet = wallet;
        }

        public void UpgradeSpeed()
        {
            if (_wallet.TryPayMoney(_price))
            {
                ChefConfig.Speed += ChefConfig.Speed * Config.UpgradeMultiply;
                _price *= Config.PriceMultiply;
            }
        }
    }
}