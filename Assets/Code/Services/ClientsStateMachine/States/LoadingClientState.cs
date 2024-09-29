using System;
using Code.Services.StateMachine;
using Code.Units.Clients;

namespace Code.Services.ClientsStateMachine.States
{
    public class LoadingClientState: IState
    {
        private readonly ClientStateMachine _clientStateMachine;
        private readonly ClientService _service;
        

        public LoadingClientState(ClientStateMachine clientStateMachine, IClientServiceProvider clientProvider)
        {
            _clientStateMachine = clientStateMachine;
            _service = clientProvider.Service;
        }

        public void Enter()
        {
            if(_service == null) throw new NullReferenceException(nameof(_service));
            _service.LoadClients();
        }

        public void Exit() => 
            _clientStateMachine.Enter<MoveToState>();
    }
}