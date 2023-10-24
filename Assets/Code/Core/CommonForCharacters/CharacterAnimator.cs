using UnityEngine;

namespace Core.CommonForCharacters
{
    public class CharacterAnimator
    {
        private readonly int _speed = Animator.StringToHash("Speed");
        private readonly int _attack = Animator.StringToHash("Attack");
        private readonly int _death = Animator.StringToHash("Death");
        
        private Animator _animator;

        public void Init(Animator animator)
        {
            _animator = animator;
        }
        
        public void SetSpeed(float speed)
        {
            _animator.SetFloat(_speed, speed);
        }

        public void PlayAttack()
        {
            _animator.SetTrigger(_attack);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(_death);
        }
    }
}