using System;
using Code.Commands;
using Code.Configs;
using Code.Movement;
using Code.Tables;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Units.Chef
{
    public class Chef : MonoBehaviour, IPlayer
    {
        public event Action<float> TaskStarted;
        public event Action TaskEnded;

        private IDisposable _timer;
        private Burger _burger;

        public bool HasBurger => _burger.IsActive;
        public IMovable Movement { get; private set; }
        public IChefConfig Config { get; private set; }

        [Inject]
        public void Construct(IChefConfig config)
        {
            gameObject.SetActive(true);
            Config = config;
        }

        private void Awake()
        {
            _burger = GetComponentInChildren<Burger>();
            Movement = GetComponent<IMovable>();
        }
        
        public void Do(ICommand command, float taskTime)
        {
            TaskStarted?.Invoke(taskTime);
            var timerTime = TimeSpan.FromSeconds(taskTime);
            _timer = Observable.Timer(timerTime)
                .Subscribe(_ =>
                {
                    command.Execute();
                    ResetTask();
                });
        }

        public void ResetTask()
        {
            TaskEnded?.Invoke();
            _timer?.Dispose();
        }

        public void TakeBurger() => 
            _burger.ShowBurger();

        public void PutBurger() => 
            _burger.HideBurger();
    }
}