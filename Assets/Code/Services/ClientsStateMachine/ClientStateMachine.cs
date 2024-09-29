using Code.Services.Factories;
using IState = Code.Services.StateMachine.IState;

namespace Code.Services.ClientsStateMachine
{
    public class ClientStateMachine
    {
        private readonly IStateFactory _factory;
        private IState _activeState;

        public ClientStateMachine(IStateFactory factory) => 
            _factory = factory;

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _factory.CreateState<TState>();
            _activeState = state;
            state.Enter();
        }
    }
}