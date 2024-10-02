using Code.Services.AssetManagement;
using Code.Services.ClientsStateMachine;
using Code.Services.Factories;
using Code.Services.SceneLoader;
using Code.Services.StateMachine;
using Code.Units.Clients;
using UnityEngine;
using Zenject;

namespace Code.Root
{
    public class GameInstaller: MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindServices();
            BindFactories();
            BindClientStateMachine();
            BindStateMachine();
        }
        
        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<ClientFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ClientServiceProvider>().AsSingle();
        }

        private void BindClientStateMachine() => 
            Container.Bind<ClientStateMachine>().AsSingle();

        private void BindSceneLoader() => 
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

        private void BindFactories() => 
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();

        private void BindStateMachine() => 
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsCached();
    }
}