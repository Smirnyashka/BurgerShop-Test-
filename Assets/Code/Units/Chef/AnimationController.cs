using UnityEngine;

namespace Code.Hero
{
    public class AnimationController
    {
        private static readonly int Walk = Animator.StringToHash("isMoving");
        private readonly Animator _animator;

        public AnimationController(Animator animator)
        {
            _animator = animator;
        }
        
        public void SetWalkAnimationState(bool value) => 
            _animator.SetBool(Walk, value);
    }
}