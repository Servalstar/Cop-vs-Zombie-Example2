using UnityEngine;

namespace Core
{
    public class PlayerComponents : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;

        public CharacterController CharacterController => _characterController;
        public Animator Animator => _animator;
    }
}