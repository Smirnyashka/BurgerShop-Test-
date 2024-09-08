using UnityEngine;
using Zenject;

namespace Code.Hero
{
    public class AnimationController: ITickable
    {

        private static readonly int Walk = Animator.StringToHash("isMoving");
        private static readonly int Attack = Animator.StringToHash("attack");


        private readonly Animator _animator;

        public AnimationController(Animator animator)
        {
            _animator = animator;
        }
        
        public void Tick()
        {
            
        }

        public void SetWalkAnimationState(bool value) => 
            _animator.SetBool(Walk,value);

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
        }
    }
}