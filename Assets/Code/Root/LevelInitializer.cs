using Code.Services.ClientsStateMachine;
using Code.Services.ClientsStateMachine.States;
using Code.Units.Clients;
using UnityEngine;
using Zenject;

namespace Code.Root
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        [field: Header("Clients")] [SerializeField]
        private ClientService _clientService;

        private IClientServiceProvider _clientServiceProvider;
        private ClientStateMachine _clientStateMachine;

        [Inject]
        private void Construct(IClientServiceProvider clientServiceProvider, ClientStateMachine clientStateMachine)
        {
            _clientStateMachine = clientStateMachine;
            _clientServiceProvider = clientServiceProvider;
        }
        
        public void Initialize()
        {
            _clientServiceProvider.Set(_clientService);
            _clientStateMachine.Enter<LoadingClientState>();
        }
    }
}