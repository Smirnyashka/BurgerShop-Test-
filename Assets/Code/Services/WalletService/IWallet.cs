using UniRx;

namespace Code.Services.WalletService
{
    public interface IWallet
    {
        public IReactiveProperty<int> Coins { get; }
        void AddMoney(int addValue);
    }
}