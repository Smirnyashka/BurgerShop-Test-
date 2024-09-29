using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using Zenject;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "NewGameSettings", menuName = "Game/GameSettings")]
    public class GameSettings : ScriptableObject, IChefConfig, IUpgradeConfig, IClientConfig
    {

        [field: Header("Chef")]
        [field: SerializeField, Range(0, 5)] public float Speed { get; set; }
        [field: SerializeField, Range(0, 5)] public float BurgerCookingSpeed { get; private set; }
        [field: SerializeField, Range(0, 5)] public float CashServiceSpeed { get; private set; }

        [field: Header("Upgrade")]
        [field: SerializeField, Range(0, 5)] public float UpgradeMultiply { get; private set; }
        [field: SerializeField, Range(0, 5)] public int PriceMultiply { get; private set; }
        
        [field: Header("Client")]
        [field: SerializeField, Range(0, 5)] public int ClientCount { get; private set; }

    }

    public interface IClientConfig
    {
        public int ClientCount { get; }
    }

    public interface IUpgradeConfig
    {
        public float UpgradeMultiply { get; }
        public int PriceMultiply { get; }
    }

    public interface IChefConfig
    {
        public float Speed { get; set; }
        public float BurgerCookingSpeed { get; }
        public float CashServiceSpeed { get; }
    }
}