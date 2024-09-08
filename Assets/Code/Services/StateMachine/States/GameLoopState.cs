using Code.Services.SceneLoader;

namespace Code.Services.StateMachine.States
{
    class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;


        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}