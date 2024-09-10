using Code.Hero;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Movement
{
    [RequireComponent(typeof(Animator))]
    public class WalkView : MonoBehaviour
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private AnimationController _animationController;
        private IMovable _movable;

        [Inject]
        public void Construct(AnimationController animationController)
        {
            _animationController = animationController;
            _movable = GetComponent<IMovable>();
        }

        private void OnEnable() =>
            _movable.IsMoving.Subscribe(isMoving => { _animationController.SetWalkAnimationState(isMoving); })
                .AddTo(_disposable);

        private void OnDisable() =>
            _disposable.Dispose();
    }
}