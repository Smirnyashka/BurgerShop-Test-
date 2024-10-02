using Code.Services.ClientsStateMachine;

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
    }
}