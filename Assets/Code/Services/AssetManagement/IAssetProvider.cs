using Code.Enemy;
using UnityEngine;

namespace Code.Services.AssetManagement
{
  public interface IAssetProvider
  {
    IClient Instantiate(string path, Vector3 at);
    GameObject Instantiate(string path);
  }
}