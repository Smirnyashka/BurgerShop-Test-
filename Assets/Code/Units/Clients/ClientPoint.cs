using Code.Services.ClientsStateMachine;
using UnityEngine;
using Zenject;

namespace Code.Units.Clients
{
    public class ClientPoint: MonoBehaviour
    {
        private ClientStateMachine _clientStateMachine;

        [Inject]
        private void Construct(ClientStateMachine clientStateMachine)
        {
            _clientStateMachine = clientStateMachine;
        }
    }
}