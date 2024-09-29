using Code.Services.AssetManagement;
using Code.Units.Clients;
using UnityEngine;

namespace Code.Services.Factories
{
    public class ClientFactory : IClientFactory
    {
        private readonly IAssetProvider _assets;

        public ClientFactory(IAssetProvider assetProvider) => 
            _assets = assetProvider;

        public IClient CreateClient(Transform at, Transform container) => 
            _assets.Instantiate(path: AssetPathes.ClientPath, at: at.transform.position, container.parent);
    }
}