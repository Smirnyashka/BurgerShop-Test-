using Code.Services.StateMachine;
using Code.Services.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private IStateMachine _stateMachine;

        [Inject]
        public void Construct(IStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        public void Start() => 
            _stateMachine.Enter<LoadingState>();
    }
}
