using Code.Configs;
using Code.Movement;
using Code.Services.CameraService;
using Code.Services.InputService;
using Code.Services.ProgressBarService;
using Code.Services.WalletService;
using Code.Tables;
using Code.Units.Chef;
using Code.Units.Clients;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Code.Root
{
    public class SceneInstaller : MonoInstaller
    {
        [field: Header("Chef")]
        [SerializeField] private GameObject _chefPrefab;
        [SerializeField] private Transform _startPoint;
        //[SerializeField]private PlayerMobileMovement _movement;
        Chef _chef;

        [field: Header("Progress Bar")] 
        //[SerializeField] private ProgressBar _progressBar;

        [field: Header("Progress Bar")]
        [SerializeField] private Joystick _joystick;
        //[SerializeField] private Chef _chef;
        [SerializeField] private GameSettings _settings;
        [SerializeField] private ClientService _clientService;
        

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            BindConfig();
            
            BindJoystick();
            BindInputService();
            //BindPlayer();
            BindPlayerRouter();
            BindAnimation();
            BindProgressBar();
            BindChef();
            BindCamera();
            BindWallet();
            
            /*Container.Resolve<IClientServiceProvider>().Set(_clientService);
            Container.Resolve<IStateMachine>().Enter<LoadingClientState>();*/
        }

        private void BindChef()
        {
            _chef = Container
                .InstantiatePrefabForComponent<Chef>(_chefPrefab, _startPoint.position, Quaternion.identity, null);
            
            Container.BindInterfacesAndSelfTo<Chef>().FromInstance(_chef).AsSingle();
            Debug.Log("Chef Instantiated");
        }
        
        private void BindProgressBar() => 
            Container.Bind<ProgressBar>().AsSingle();

        private void BindConfig() => 
            Container.BindInterfacesAndSelfTo<GameSettings>().FromInstance(_settings).AsSingle();
        
        private void BindJoystick() =>
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
        
        private void BindInputService() =>
            Container.BindInterfacesAndSelfTo<JoystickInput>().AsCached();
        
        /*private void BindPlayer() => 
            Container.BindInterfacesAndSelfTo<Chef>().FromInstance(_chef).AsSingle();*/
        
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