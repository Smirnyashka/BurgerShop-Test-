using System;
using Code.Commands;
using Code.Configs;
using Code.Movement;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Units.Chef
{
    public class Chef : MonoBehaviour, IPlayer
    {
        public event Action OnTaskStarted;
        public event Action OnTaskEnded;
        
        private IDisposable _timer;
        
        public IDisposable Timer => _timer;
        
        public IMovable Movement { get; private set; }
        public IChefConfig Config { get; private set; }

        [Inject]
        public void Construct(IChefConfig config) => 
            Config = config;

        private void Awake() => 
            Movement = GetComponent<IMovable>();

        public void Do(ICommand command)
        {
            OnTaskStarted?.Invoke();
            var timerTime = TimeSpan.FromSeconds(5);
            _timer = Observable.Timer(timerTime)
                .Subscribe(_ =>
                {
                    command.Execute();
                    ResetTask();
                });
        }

        public void ResetTask()
        {
            OnTaskEnded?.Invoke();
            _timer.Dispose();
        }
    }
}