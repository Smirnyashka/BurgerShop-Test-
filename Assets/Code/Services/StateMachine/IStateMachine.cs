namespace Code.Services.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IState;
    }
}