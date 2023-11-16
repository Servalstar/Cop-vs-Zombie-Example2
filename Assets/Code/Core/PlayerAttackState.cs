using Configs;
using Core.CommonForCharacters;
using Core.CommonForCharacters.Contracts;
using Services.Input.Contracts;
using UnityEngine;

namespace Core
{
    public class PlayerAttackState : IState
    {
        private readonly Collider[] _hits = new Collider[20];
        private int _layerMask;
        private float _attackLeftTime;
        private Transform _transform;
        private ICharacterStateMachine _stateMachine;
        private CharacterAnimator _animator;
        private ParticleSystem _particles;
        private CharacterModel _model;
        private PlayerConfig _playerConfig;
        private IInputService _inputService;

        public void Init(ICharacterStateMachine stateMachine, Transform transform, 
            PlayerConfig playerConfig, IInputService inputService, CharacterAnimator animator, 
            ParticleSystem particles, CharacterModel model)
        {
            _inputService = inputService;
            _playerConfig = playerConfig;
            _model = model;
            _animator = animator;
            _particles = particles;
            _stateMachine = stateMachine;
            _transform = transform;
            
            _layerMask = 1 << LayerMask.NameToLayer(_playerConfig.AttackLayerName);
        }
        
        public void Execute()
        {
            if (!_model.IsAlive())
            {
                _stateMachine.ChangeState(CharacterState.Death);
                return;
            }
            
            if (IsMoving())
            {
                _stateMachine.ChangeState(CharacterState.Move);
                return;
            }
            
            UpdateCooldown();

            if (CanAttack())
            {
                TryAttack();
            }
        }

        private void TryAttack()
        {
            if (GetNearestTarget(out Collider target) > 0)
            {
                _transform.LookAt(target.transform.position);
                _animator.PlayAttack();
                _particles.Play();
                _attackLeftTime = _playerConfig.Cooldown;

                target.transform.GetComponent<IDamageable>().TakeDamage(_playerConfig.Damage);
            }
        }

        private void UpdateCooldown()
        {
            if (CooldownIsFinished() == false)
            {
                _attackLeftTime -= Time.deltaTime;
            }
        }

        private bool CanAttack()
        {
            return CooldownIsFinished() && !IsMoving() && _model.IsAlive();
        }

        private bool CooldownIsFinished()
        {
            return _attackLeftTime <= 0f;
        }

        private bool IsMoving()
        {
            return _inputService.Direction.sqrMagnitude > Mathf.Epsilon;
        }

        private int GetNearestTarget(out Collider target)
        {
            var hitAmount = Physics.OverlapSphereNonAlloc(_transform.position, _playerConfig.AttackRadius, _hits, _layerMask);
            target = FindNearestTarget(_hits, hitAmount);

            return hitAmount;
        }

        private Collider FindNearestTarget(Collider[] targets, int hitAmount)
        {
            var distance = float.MaxValue;
            Collider nearestTarget = null;

            for (var i = 0; i < hitAmount; i++)
            {
                var currentDistance = Vector3.Distance(_transform.position, targets[i].transform.position);

                if (currentDistance < distance)
                {
                    distance = currentDistance;
                    nearestTarget = targets[i];
                }
            }

            return nearestTarget;
        }
    }
}