using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    public class EnemyComponents : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;

        public NavMeshAgent NavMeshAgent => _agent;
        public Animator Animator => _animator;
    }
}