using Code.Services.ClientsStateMachine;
using Code.Services.ClientsStateMachine.States;
using UnityEngine;

namespace Code.Services.StateMachine.States
{
    class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ClientStateMachine _clientStateMachine;

        public GameLoopState(GameStateMachine gameStateMachine, ClientStateMachine clientStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _clientStateMachine = clientStateMachine;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}