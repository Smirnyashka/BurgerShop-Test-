using Code.Services.SceneLoader;
using Code.Units.Clients;

namespace Code.Services.StateMachine.States
{
    public class LoadingState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStateMachine _stateMachine;

        public LoadingState(ISceneLoader sceneLoader, IStateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        public void Enter()
        { 
            _sceneLoader.LoadScene("GameLoopScene");
            _stateMachine.Enter<GameLoopState>();
        }
    }
}