using Code.Services.ProgressBarService;
using UnityEngine;
using Zenject;

namespace Code.Services.CameraService
{
    public class LookAtCamera: ITickable
    {
        private readonly ProgressBar _bar;
        private readonly Camera _camera;

        private LookAtCamera(Camera camera, ProgressBar bar)
        {
            _camera = camera;
            _camera = Camera.main;
            _bar = bar;
        }
        
        public void Tick() => 
            _bar.transform.LookAt(_camera.transform);
    }
}