using System;
using System.Collections.Generic;
using Code.Services.Factories;

namespace Code.Services.StateMachine
{
    public class GameStateMachine: IStateMachine
    {
        private readonly StateFactory _stateFactory;
        
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _stateFactory.CreateState<TState>();
            _activeState = state;
            state.Enter();
        }
    }
}