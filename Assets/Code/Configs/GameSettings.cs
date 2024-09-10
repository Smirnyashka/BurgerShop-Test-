using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using Zenject;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "NewGameSettings", menuName = "Game/GameSettings")]
    public class GameSettings : ScriptableObject, IChefConfig
    {
        [field: Header("Chef")]
        [field: SerializeField, Range(0, 5)] public float Speed { get; private set; }
        [field: SerializeField, Range(0, 5)] public float BurgerCookingSpeed { get; private set; }
        [field: SerializeField, Range(0, 5)] public float CashServiceSpeed { get; private set; }
    }

    public interface IChefConfig
    {
        public float Speed { get; }
        public float BurgerCookingSpeed { get; }
        public float CashServiceSpeed { get; }
    }
}