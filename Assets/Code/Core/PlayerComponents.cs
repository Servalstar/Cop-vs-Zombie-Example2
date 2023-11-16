using UnityEngine;

namespace Core
{
    public class PlayerComponents : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem _particles;

        public CharacterController CharacterController => _characterController;
        public Animator Animator => _animator;
        public ParticleSystem Particles => _particles;
    }
}