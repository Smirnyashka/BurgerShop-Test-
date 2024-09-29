using Code.Units.Clients;
using UnityEngine;

namespace Code.Services.AssetManagement
{
  public interface IAssetProvider
  {
    IClient Instantiate(string path, Vector3 at, Transform parent);
    GameObject Instantiate(string path);
  }
}