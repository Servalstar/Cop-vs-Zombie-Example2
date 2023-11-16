using Core.CommonForCharacters;
using Core.CommonForCharacters.Contracts;
using Services.Input.Contracts;
using UnityEngine;

namespace Core
{
    public class PlayerMoveState : IState
    {
        private CharacterController _characterController;
        private Camera _camera;
        private Transform _transform;
        private float _movementSpeed;
        private CharacterAnimator _animator;
        private IInputService _inputService;

        private ICharacterStateMachine _stateMachine;
        private CharacterModel _model;

        public void Init(ICharacterStateMachine stateMachine, Transform transform,
            CharacterController characterController, float movementSpeed,
            IInputService inputService, CharacterAnimator animator, CharacterModel model)
        {
            _stateMachine = stateMachine;
            _model = model;
            _inputService = inputService;
            _animator = animator;
            _transform = transform;
            _characterController = characterController;
            _camera = Camera.main;
            _movementSpeed = movementSpeed;
        }

        public void Execute()
        {
            if (!_model.IsAlive())
            {
                _stateMachine.ChangeState(CharacterState.Death);
                return;
            }
            
            if (!IsMoving())
            {
                _stateMachine.ChangeState(CharacterState.Attack);
                _animator.SetSpeed(0);
                return;
            }
            
            Move(_inputService.Direction);
        }

        private void Move(Vector2 direction)
        {
            var movementVector = _camera.transform.TransformDirection(direction);
            movementVector.y = 0;
            movementVector.Normalize();

            _transform.forward = movementVector;
            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);

            var currentSpeed = _characterController.velocity.magnitude;
            _model.CurrentSpeed = currentSpeed;
            _animator.SetSpeed(currentSpeed);
        }

        private bool IsMoving()
        {
            return _inputService.Direction.sqrMagnitude > Mathf.Epsilon;
        }
    }
}