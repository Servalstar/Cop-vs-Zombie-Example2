using Services.Input.Contracts;
using UnityEngine;

namespace Core
{
    public class PlayerDeathState : IState
    {
        private CharacterController _characterController;
        private Camera _camera;
        private Transform _transform;
        private float _movementSpeed;

        public void Init(Transform transform, CharacterController characterController, float movementSpeed,
            IInputService inputService, Animator playerComponentsAnimator)
        {
            _transform = transform;
            _characterController = characterController;
            _camera = Camera.main;
            _movementSpeed = movementSpeed;
        }


        public void Execute()
        {
            
        }
    }
}