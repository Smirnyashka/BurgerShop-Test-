using Code.Configs;
using Code.Movement;
using Code.Services.AssetManagement;
using Code.Services.CameraService;
using Code.Services.ClientsStateMachine;
using Code.Services.ClientsStateMachine.States;
using Code.Services.InputService;
using Code.Services.ProgressBarService;
using Code.Services.StateMachine;
using Code.Services.WalletService;
using Code.Units.Chef;
using Code.Units.Clients;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Code.Root
{
    public class SceneInstaller : MonoInstaller
    {
        [field: Header("Chef")] [SerializeField]
        private GameObject _chefPrefab;

        [SerializeField] private Transform _startPoint;

        [field: Header("Progress Bar")] [SerializeField]
        private ProgressBar _progressBar;

        [field: Header("Joystick")] [SerializeField]
        private Joystick _joystick;

        [field: Header("Config")] [SerializeField]
        private GameSettings _settings;

        [field: Header("Config")] [SerializeField]
        private LevelInitializer _levelInitializer;

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            BindConfig();
            BindJoystick();
            BindInputService();
            BindPlayerRouter();
            BindAnimation();
            BindChef();
            BindProgressBar();
            BindCamera();
            BindWallet();

            Container.BindInterfacesAndSelfTo<LevelInitializer>().FromInstance(_levelInitializer).AsSingle();
        }

        private void BindChef()
        {
            Chef chef = Container.InstantiatePrefabForComponent<Chef>(
                _chefPrefab, _startPoint.position, Quaternion.identity, null);

            Container.BindInterfacesAndSelfTo<Chef>().FromInstance(chef).AsSingle();
        }

        private void BindProgressBar() =>
            Container.Bind<ProgressBar>().FromInstance(_progressBar).AsSingle();

        private void BindConfig() =>
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(_settings).AsSingle();

        private void BindJoystick() =>
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();

        private void BindInputService() =>
            Container.BindInterfacesAndSelfTo<JoystickInput>().AsCached();

        private void BindPlayerRouter() =>
            Container.BindInterfacesAndSelfTo<PlayerRouter>().AsCached();

        private void BindAnimation()
        {
            Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<WalkView>().AsSingle();
        }

        private void BindCamera()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<LookAtCamera>().AsSingle();
        }

        private void BindWallet() =>
            Container.BindInterfacesAndSelfTo<Wallet>().AsSingle();
    }
}