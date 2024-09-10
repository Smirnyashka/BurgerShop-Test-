using Code.Enemy;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Services.AssetManagement
 {
    public class AssetProvider: IAssetProvider
    {
        public IClient Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            var instantiatedObject = Object.Instantiate(prefab, at, Quaternion.identity);
            var clientComponent = instantiatedObject.GetComponent<IClient>();
            return clientComponent;
        }
        
        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
     }
 }