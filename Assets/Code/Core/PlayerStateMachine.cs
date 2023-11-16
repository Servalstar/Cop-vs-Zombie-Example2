using System.Collections.Generic;
using Configs;
using Core.CommonForCharacters;
using Core.CommonForCharacters.Contracts;
using Services.Input.Contracts;

namespace Core
{
    public class PlayerStateMachine : ICharacterStateMachine
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerMoveState _playerMoveState;
        private readonly PlayerAttackState _playerAttackState;
        private readonly PlayerDeathState _playerDeathState;
        private readonly CharacterAnimator _characterAnimator;
        private readonly IInputService _inputService;
        private PlayerComponents _playerComponents;

        private Dictionary<CharacterState, IState> _states;
        private CharacterState _currentState;

        public PlayerStateMachine(
            PlayerModel playerModel, 
            PlayerMoveState playerMoveState,
            PlayerAttackState playerAttackState,
            PlayerDeathState playerDeathState,
            CharacterAnimator characterAnimator, 
            IInputService inputService)
        {
            _playerModel = playerModel;
            _playerMoveState = playerMoveState;
            _playerAttackState = playerAttackState;
            _playerDeathState = playerDeathState;
            _characterAnimator = characterAnimator;
            _inputService = inputService;
        }

        public void InitStates(PlayerComponents playerComponents, PlayerConfig playerConfig)
        {
            _playerComponents = playerComponents;
            _playerModel.Transform = _playerComponents.transform;
            _playerModel.Health.Init(playerConfig.MaxHealth);
            _characterAnimator.Init(playerComponents.Animator);

            _playerMoveState.Init(this, playerComponents.transform, playerComponents.CharacterController, 
                playerConfig.MovementSpeed, _inputService, _characterAnimator, _playerModel);

            _playerAttackState.Init(this, playerComponents.transform, playerConfig, 
                _inputService, _characterAnimator, _playerComponents.Particles, _playerModel);
            
            _states = new Dictionary<CharacterState, IState>
            {
                [CharacterState.Move] = _playerMoveState,
                [CharacterState.Attack] = _playerAttackState,
                [CharacterState.Death] = _playerDeathState
            };
        }

        public void ChangeState(CharacterState newState)
        {
            _currentState = newState;
        }
        
        public void Tick()
        {
            _states?[_currentState].Execute();
        }
    }
}