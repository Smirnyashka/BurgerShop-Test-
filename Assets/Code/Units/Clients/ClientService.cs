using System;
using System.Collections.Generic;
using Code.Commands;
using Code.Services.AssetManagement;
using Code.Services.Factories;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Units.Clients
{
    public class ClientService : MonoBehaviour
    {
        private readonly Queue<IClient> _clients = new();

        private IAssetProvider _assetProvider;
        private IClientFactory _factory;

        private IClient _current;

        private int _clientCount = 3;

        public bool IsSend => _current != null;


        [Header("Queue")] 
        [SerializeField] private float _queueMoveDuration;

        [Header("Clients spawn")] 
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Transform _spawn;
        
        [Header("Order window")] 
        [SerializeField] private Transform _payDesk;
        [SerializeField] private float _payDeskDuration;

        [Header("Away")]
        [SerializeField] private Transform _away;
        [SerializeField] private float _awayDuration;


        [Inject]
        private void Construct(AssetProvider assetProvider, ClientFactory factory)
        {
            _assetProvider = assetProvider;
            _factory = factory;
        }

        public void LoadClients()
        {
            if (_assetProvider == null) throw new NullReferenceException("Asset provider is null");
            if (_factory == null) throw new NullReferenceException("Factory is null");
            for (int i = 0; i < _clientCount; i++)
                _clients.Enqueue(_factory.CreateClient(_spawn, _spawn));
        }

        public void SendClient()
        {
            IClient client = DequeueClient();

            ICommand moveToWindow =
                new MoveTo(client, _payDesk, _payDeskDuration);

            client.Do(moveToWindow, () =>
                OnMoved(_payDeskDuration, () => _current = client)
            );
        }

        private IClient DequeueClient()
        {
            IClient last = _clients.Dequeue();
            IClient previous = last;

            foreach (var client in _clients)
            {
                ICommand moveToPrevious =
                    new MoveTo(client, previous.Transform, _queueMoveDuration);

                client.Do(moveToPrevious);

                previous = client;
            }

            return last;
        }

        public void ReturnClient()
        {
            if (_current == null)
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