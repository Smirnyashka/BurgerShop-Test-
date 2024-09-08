// using Cysharp.Threading.Tasks;
// using UnityEngine;
// using Zenject;
//
// namespace Code.Services.Factories
// {
//     public class GameFactory
//     {
//         private readonly AssetProvider.AssetProvider _asset;
//         private readonly IInstantiator _instantiator;
//
//         public GameFactory(AssetProvider asset, IInstantiator instantiator)
//         {
//             _asset = asset;
//             _instantiator = instantiator;
//         }
//
//         public GameObject Create(string path)
//         {
//             var prefab = _asset.Instantiate(path);
//             return _instantiator.InstantiatePrefab(prefab);
//         }
//
//         public async UniTask<GameObject> Create(string path)
//         {
//             var prefab = await _asset.Instantiate(path);
//             return prefab;
//         }
//     }
// }