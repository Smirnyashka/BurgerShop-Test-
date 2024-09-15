using System;
using Code.Hero;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Movement
{
    public class WalkView : MonoBehaviour
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private Animator _animator;
        private IMovable _movable;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _movable = GetComponent<IMovable>();
        }

        private void OnEnable() =>
            _movable.IsMoving.Subscribe(isMoving => { _animator.SetBool(AnimationHashes.Walk, isMoving); })
                .AddTo(_disposable);

        private void OnDisable() =>
            _disposable.Dispose();
    }
}