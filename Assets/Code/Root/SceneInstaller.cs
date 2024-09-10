using Code.Configs;
using Code.Enemy;
using Code.Hero;
using Code.Movement;
using Code.Services.AssetManagement;
using Code.Services.CameraService;
using Code.Services.Factories;
using Code.Services.InputService;
using Code.Tables;
using Code.Units.Chef;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Root
{
    public class SceneInstaller : MonoInstaller
    {

        [field: Header("Progress Bar")] 
        [SerializeField] private ProgressBar _progressBar;

        [field: Header("Progress Bar")]
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Chef _chef;
        [SerializeField] private GameSettings _settings;
        [SerializeField] private PlayerMobileMovement _movement;

        public override void InstallBindings()
        {
            BindConfigProvider();
            BindJoystick();
            BindInputService();
            BindPlayer();
            BindPlayerRouter();
            BindServices();
            BindAnimation();
            BindProgressBar();
            BindTrash();
        }

        private void BindProgressBar()
        {
            Container.Bind<ProgressBar>().FromInstance(_progressBar).AsSingle();
        }

        private void BindConfigProvider()
        {
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(_settings).AsSingle();
        }
        

        private void BindTrash()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<LookAtCamera>().AsSingle();
        }

        private void BindAnimation()
        {
            Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimationController>().AsSingle();
            Container.BindInterfacesAndSelfTo<WalkView>().AsSingle();
        }

        private void BindPlayerRouter()
        {
            //Container.BindInterfacesAndSelfTo<PlayerMobileMovement>().FromInstance(_movement).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerRouter>().AsCached();
        }

        private void BindPlayer() => 
            Container.BindInterfacesAndSelfTo<Chef>().FromInstance(_chef).AsSingle();

        private void BindInputService() =>
            Container.BindInterfacesAndSelfTo<JoystickInput>().AsCached();

        private void BindJoystick() =>
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();


        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IClientFactory>().To<ClientFactory>().AsSingle();
        }
    }
}