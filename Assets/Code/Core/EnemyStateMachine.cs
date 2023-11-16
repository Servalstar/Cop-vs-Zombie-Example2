using Configs;
using Core.CommonForCharacters;
using Core.CommonForCharacters.Contracts;
using UnityEngine;

namespace Core
{
    public class EnemyStateMachine : ICharacterStateMachine
    {
        private readonly CharacterModel _enemyModel;
        private readonly PlayerModel _playerModel;
        private readonly EnemyMover _enemyMover;
        private readonly CharacterAnimator _characterAnimator;
        private CurrentState _currentState;
        private EnemyComponents _enemyComponents;
        private EnemyConfig _enemyConfig;

        private bool CanMove => _playerModel.Transform != null && _enemyModel.IsAlive() && IsHeroNotReached();

        public EnemyStateMachine(
            CharacterModel enemyModel,
            PlayerModel playerModel,
            EnemyMover enemyMover, 
            CharacterAnimator characterAnimator)
        {
            _enemyModel = enemyModel;
            _playerModel = playerModel;
            _enemyMover = enemyMover;
            _characterAnimator = characterAnimator;
        }

        public void Init(EnemyComponents enemyComponents, EnemyConfig enemyConfig)
        {
            _enemyConfig = enemyConfig;
            _enemyComponents = enemyComponents;
            
            _enemyMover.Init(enemyComponents.NavMeshAgent);
            _characterAnimator.Init(enemyComponents.Animator);
            
            _enemyModel.Init(enemyConfig.MaxHealth);
        }
        
        public void Tick()
        {
            if (_currentState == CurrentState.Active && CanMove)
            {
                _enemyMover.Move(_playerModel.Transform.position);
                _enemyModel.CurrentSpeed = _enemyComponents.NavMeshAgent.velocity.magnitude;
                _characterAnimator.SetSpeed(_enemyModel.CurrentSpeed);
            }
        }

        public void ChangeState(CharacterState newState)
        {
            
        }

        public void Activate()
        {
            _currentState = CurrentState.Active;
        }

        public void SetInactive()
        {
            _currentState = CurrentState.InActive;
        }

        private bool IsHeroNotReached()
        {
            var currentDistance = (_enemyComponents.transform.position - _playerModel.Transform.position).sqrMagnitude;
            return currentDistance > Mathf.Pow(_enemyConfig.StopDistance, 2);
        }

        private enum CurrentState
        {
            InActive = 0,
            Active = 1,
            Death = 2
        }
    }
}