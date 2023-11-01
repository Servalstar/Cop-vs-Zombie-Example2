using Configs;
using Core.CommonForCharacters;
using Core.CommonForCharacters.Contracts;
using Services.Input.Contracts;
using Zenject;

namespace Core
{
    public class PlayerBehaviour : ITickable, IBehaviour
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerMover _playerMover;
        private readonly CharacterAnimator _characterAnimator;
        private readonly IInputService _inputService;
        private CurrentState _currentState;
        private PlayerComponents _playerComponents;
        
        private bool CanMove => _playerModel.IsAlive();

        public PlayerBehaviour(
            PlayerModel playerModel, 
            PlayerMover playerMover, 
            CharacterAnimator characterAnimator, 
            IInputService inputService)
        {
            _playerModel = playerModel;
            _playerMover = playerMover;
            _characterAnimator = characterAnimator;
            _inputService = inputService;
        }

        public void Init(PlayerComponents playerComponents, PlayerConfig playerConfig)
        {
            _playerComponents = playerComponents;
            _playerMover.Init(playerComponents.transform, playerComponents.CharacterController, playerConfig.MovementSpeed);
            _characterAnimator.Init(playerComponents.Animator);

            _playerModel.Transform = _playerComponents.transform;
        }
        
        public void Tick()
        {
            if (_currentState == CurrentState.Active)
            {
                _playerMover.Move(_inputService.Direction);
                _playerModel.CurrentSpeed = _playerComponents.CharacterController.velocity.magnitude;
                _characterAnimator.SetSpeed(_playerModel.CurrentSpeed);
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