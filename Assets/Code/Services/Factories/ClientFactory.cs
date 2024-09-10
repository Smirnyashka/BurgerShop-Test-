using System;
using Code.Enemy;
using Code.Services.AssetManagement;
using UnityEngine;

namespace Code.Services.Factories
{
    public class ClientFactory: IClientFactory
    {
        private readonly IAssetProvider _assets;

        public ClientFactory(IAssetProvider assetProvider)
        {
            _assets = new AssetProvider();
        }

        public IClient CreateClient(Transform at)
        {
            if (_assets == null) throw new NullReferenceException(nameof(_assets));
            return _assets.Instantiate(path: AssetPathes.ClientPath, at: at.transform.position);
        }
    }
}