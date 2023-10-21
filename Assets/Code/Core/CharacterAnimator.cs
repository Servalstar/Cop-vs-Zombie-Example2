using UnityEngine;

namespace Core
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Mover _mover;
        
        private readonly int _speed = Animator.StringToHash("Speed");
        private readonly int _attack = Animator.StringToHash("Attack");
        private readonly int _death = Animator.StringToHash("Death");

        private void Update()
        {
            _animator.SetFloat(_speed, _mover.CurrentSpeed);
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