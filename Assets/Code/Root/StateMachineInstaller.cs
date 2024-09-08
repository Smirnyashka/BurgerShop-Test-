using Code.Services.StateMachine.States;
using Zenject;

namespace Code.Root
{
    public class StateMachineInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadingState>().AsSingle().NonLazy();
            Container.Bind<GameLoopState>().AsSingle().NonLazy();
        }
    }
}