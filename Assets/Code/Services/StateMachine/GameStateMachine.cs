using System;
using System.Collections.Generic;
using Code.Services.Factories;
using Code.Services.StateMachine.States;
using Zenject;

namespace Code.Services.StateMachine
{
    public class GameStateMachine: IStateMachine, IInitializable
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
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }

        public void Initialize()
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LoadingState)] = _stateFactory.CreateState<LoadingState>(),
                [typeof(GameLoopState)] = _stateFactory.CreateState<GameLoopState>()
            };
        }
    }
}