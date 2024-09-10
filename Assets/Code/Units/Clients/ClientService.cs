using System;
using System.Collections.Generic;
using Code.Commands;
using Code.Services.AssetManagement;
using Code.Services.Factories;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Enemy
{
    public class ClientService: MonoBehaviour
    {
        private readonly Queue<IClient> _clients = new();
        //[SerializeField]private Transform _spawnPoint;
        
        private IClientFactory _factory;
        private IAssetProvider _assetProvider;
        private int _clientCount = 3;
        
        private IClient _current;

        public bool IsSend => _current != null;
        
        
        [Header("Queue")] 
        [SerializeField] private float _queueMoveDuration;
        
        [Header("Clients spawn")]
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Transform _spawn;
        
        [Header("Order window")]
        [SerializeField] private Transform _window;
        [SerializeField] private float _windowDuration;
        
        [Header("Away")]
        [SerializeField] private Transform _away;
        [SerializeField] private float _awayDuration;

        private void Awake()
        {
            _factory = new ClientFactory(_assetProvider);
        }

        public void LoadClients()
        {
            for (int i = 0; i < _clientCount; i++)
            {
                _clients.Enqueue(_factory.CreateClient(transform));
            }
        }
        
        public void SendClient()
        {
            IClient client = DequeueClient();

            ICommand moveToWindow = 
                new MoveTo(client, _window, _windowDuration);
            
            client.Do(moveToWindow, () => 
                OnMoved(_windowDuration, () => _current = client)
            );
        }
        
        private IClient DequeueClient()
        {
            IClient last = _clients.Dequeue();
            IClient previos = last;

            foreach (var client in _clients)
            {
                ICommand moveToPrevios = 
                    new MoveTo(client, previos.Transform, _queueMoveDuration);

                client.Do(moveToPrevios);

                previos = client;
            }

            return last;
        }
        
        public void ReturnClient()
        {
            if(_current == null)
                throw new InvalidOperationException();

            ICommand goAway = 
                new MoveTo(_current, _away, _awayDuration);
            
            _current.Do(goAway, () => 
                OnMoved(_awayDuration, BackClientToQueue)
            );
        }
        
        private async void OnMoved(float duration, Action callback)
        {
            await UniTask.WaitForSeconds(duration);
            callback.Invoke();
        }
        
        private void BackClientToQueue()
        {
            _current.Transform.position = GetPosition(_clients.Count);
            _clients.Enqueue(_current);
            _current = null;
        }
        
        private Vector3 GetPosition(int queuePosition) => 
            _spawn.position + queuePosition * _offset;

    }
}