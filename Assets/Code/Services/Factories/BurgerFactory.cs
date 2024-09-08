using Code.Services.AssetProvider;
using UnityEngine;

namespace Code.Services.Factories
{
    public class BurgerFactory
    {
        private AssetPathes _assetPathes;

        public BurgerFactory(AssetPathes assetPathes)
        {
            _assetPathes = assetPathes;
        }

        /*public GameObject Create(string Path)
        {
            var prefab = Resources.Load(Path);
            var burger = prefab.Instantiate
        }*/
        
        
    }
}