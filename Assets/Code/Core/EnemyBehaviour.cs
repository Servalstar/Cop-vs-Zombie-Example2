using Configs;
using Core.CommonForCharacters;
using Core.CommonForCharacters.Contracts;
using Services.Input.Contracts;
using Zenject;

namespace Core
{
    public class EnemyBehaviour : ITickable, IBehaviour
    {
        private readonly CharacterModel _characterModel;
        private readonly CharacterMover _characterMover;
        private readonly CharacterAnimator _characterAnimator;
        private readonly IInputService _inputService;
        private CurrentState _currentState;
        private EnemyComponents _enemyComponents;
        
        private bool CanMove => _characterModel.IsAlive();

        public EnemyBehaviour(
            CharacterModel characterModel, 
            CharacterMover characterMover, 
            CharacterAnimator characterAnimator, 
            IInputService inputService)
        {
            _characterModel = characterModel;
            _characterMover = characterMover;
            _characterAnimator = characterAnimator;
            _inputService = inputService;
        }

        public void Init(EnemyComponents enemyComponents, EnemyConfig enemyConfig)
        {
            _enemyComponents = enemyComponents;
            //_characterMover.Init(enemyComponents.transform, enemyComponents.CharacterController, playerConfig.MovementSpeed);
            _characterAnimator.Init(enemyComponents.Animator);
        }
        
        public void Tick()
        {
            if (_currentState == CurrentState.Active)
            {
                //_characterMover.Move(_inputService.Direction);
                //_characterModel.CurrentSpeed = _playerComponents.CharacterController.velocity.magnitude;
                //_characterAnimator.SetSpeed(_characterModel.CurrentSpeed);
            }
        }

        public void Activate()
        {
            _currentState = CurrentState.Active;
        }

        public void SetInactive()
        {
            _currentState = CurrentState.InActive;
        }

        private enum CurrentState
        {
            InActive = 0,
            Active = 1,
            Death = 2
        }
    }
}