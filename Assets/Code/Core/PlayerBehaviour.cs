using Configs;
using Core.CommonForCharacters;
using Services.Input.Contracts;
using Zenject;

namespace Core
{
    public class PlayerBehaviour : ITickable
    {
        private readonly CharacterModel _characterModel;
        private readonly CharacterMover _characterMover;
        private readonly CharacterAnimator _characterAnimator;
        private readonly IInputService _inputService;
        private CurrentState _currentState;
        private PlayerComponents _playerComponents;
        
        private bool CanMove => _characterModel.IsAlive();

        public PlayerBehaviour(
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

        public void Init(PlayerComponents playerComponents, PlayerConfig playerConfig)
        {
            _playerComponents = playerComponents;
            _characterMover.Init(playerComponents.transform, playerComponents.CharacterController, playerConfig.MovementSpeed);
            _characterAnimator.Init(playerComponents.Animator);
        }
        
        public void Tick()
        {
            if (_currentState == CurrentState.Active)
            {
                _characterMover.Move(_inputService.Direction);
                _characterModel.CurrentSpeed = _playerComponents.CharacterController.velocity.magnitude;
                _characterAnimator.SetSpeed(_characterModel.CurrentSpeed);
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