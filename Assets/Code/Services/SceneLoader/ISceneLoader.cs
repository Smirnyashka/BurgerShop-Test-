using System;

namespace Code.Services.SceneLoader
{
    public interface ISceneLoader
    {
       public void LoadScene(string name, Action onLoaded = null);
    }
}