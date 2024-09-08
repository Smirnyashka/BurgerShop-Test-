using Code.Hero;
using Code.Services.AssetProvider;
using Code.Services.InputService;
using UnityEngine;
using Zenject;

namespace Code.Root
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]private PlayerMobileMovement heroPlayerMovement;
        
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
        }

        private void BindConfigs()
        {
            Container.Bind<AssetPathes>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<GameInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMobileMovement>().FromInstance(heroPlayerMovement).AsSingle();
            Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
        }
    }
}