using System;
using Code.Services.InputService;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Hero
{
    [RequireComponent(typeof(Animator))]
    public class WalkView : MonoBehaviour
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private AnimationController _animationController;
        private IMovable _movable;

        [Inject]
        public void Contruct(IMovable movable,AnimationController animationController)
        {
            _movable = movable;
            _animationController = animationController;
        }

        private void OnEnable()
        {
            _movable.IsMoving.Subscribe(isMoving =>
            {
                _animationController.SetWalkAnimationState(isMoving);
            }).AddTo(_disposable);
        }

        private void OnDisable() =>
            _disposable.Dispose();
    }
}