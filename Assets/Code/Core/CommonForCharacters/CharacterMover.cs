using UnityEngine;

namespace Core.CommonForCharacters
{
    public class CharacterMover
    {
        private CharacterController _characterController;
        private Camera _camera;
        private Transform _transform;
        private float _movementSpeed;

        public void Init(Transform transform, CharacterController characterController, float movementSpeed)
        {
            _transform = transform;
            _characterController = characterController;
            _camera = Camera.main;
            _movementSpeed = movementSpeed;
        }
        
        public void Move(Vector2 direction)
        {
            if (IsMoving(direction))
            {
                var movementVector = _camera.transform.TransformDirection(direction);
                movementVector.y = 0;
                movementVector.Normalize();

                _transform.forward = movementVector;
                _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
            }
        }
        
        private bool IsMoving(Vector2 direction)
        {
            return direction.sqrMagnitude > Mathf.Epsilon;
        }
    }
}