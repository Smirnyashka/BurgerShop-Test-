using Code.Units.Clients;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Services.AssetManagement
 {
    public class AssetProvider: IAssetProvider
    {
        public IClient Instantiate(string path, Vector3 at, Transform container)
        {
            var prefab = Resources.Load<GameObject>(path);
            var instantiatedObject = Object.Instantiate(prefab, at, Quaternion.identity, container.parent);
            instantiatedObject.SetActive(true);
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