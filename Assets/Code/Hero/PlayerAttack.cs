using Cysharp.Threading.Tasks;

namespace Code.Hero
{
    public class PlayerAttack : IAttackble
    {
        private IAttackble _attackble;
        private AnimationController _animationController;
        private float _attackRange = 1.5f;

        public PlayerAttack(AnimationController animationController)
        {
            _animationController = animationController;
        }

        public async void Attack()
        {
             _animationController.PlayAttack();
             await UniTask.WaitForSeconds(1);
             _animationController.PlayAttack();
        }
    }
}