using Code.Services.StateMachine;
using Code.Units.Clients;

namespace Code.Services.ClientsStateMachine.States
{
    class MoveToState : IState
    {
        private readonly ClientStateMachine _clientStateMachine;
        private IClient _client;

        public MoveToState(ClientStateMachine clientStateMachine)
        {
            _clientStateMachine = clientStateMachine;
        }

        public void Enter()
        {
        }
    }
}