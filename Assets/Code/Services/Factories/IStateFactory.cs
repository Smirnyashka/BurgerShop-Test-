using Code.Services.StateMachine;

namespace Code.Services.Factories
{
    public interface IStateFactory
    {
        public IState CreateState<TState>() where TState : IState;
    }
}