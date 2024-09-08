using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;


namespace Code.Services.SceneLoader
{
    public sealed class SceneLoader : ISceneLoader
    {
        public async void LoadScene(string name, Action onLoaded = null)
        {
            AsyncOperation handle = SceneManager.LoadSceneAsync(name);
            await handle.ToUniTask();

            handle.completed += _ => onLoaded?.Invoke();
        }
    }
}