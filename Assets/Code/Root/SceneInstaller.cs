using Code.Configs;
using Code.Hero;
using Code.Services.AssetProvider;
using Code.Services.InputService;
using UnityEngine;
using Zenject;

namespace Code.Root
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]private PlayerMovement heroPlayerMovement;
        
        public override void InstallBindings()
        {
            BindConfigs();
            BindServices();
            BindUnits();
            BindAnimation();
        }

        private void BindAnimation()
        {
            Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimationController>().AsSingle();
        }

        private void BindUnits()
        {
            Container.Bind<HeroConfig>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMovement>().FromInstance(heroPlayerMovement).AsSingle();
            Container.Bind<IAttackble>().To(typeof(PlayerAttack)).AsSingle();
        }

        private void BindConfigs()
        {
            Container.Bind<AssetPathes>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<GameInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<SimpleInput>().AsSingle();
        }
    }
}