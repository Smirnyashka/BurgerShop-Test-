using UnityEngine;

namespace Code.Configs
{
    public class ChefConfig : MonoBehaviour,IChefConfig
    {
        [field: Header("Chef")]
        [field: SerializeField, Range(0, 5)] public float BurgerCookingSpeed { get; private set; }
        [field: SerializeField, Range(0, 5)] public float Speed { get; private set; }
        [field: SerializeField, Range(0, 5)] public float CashServiceSpeed { get; private set; }
    }
}