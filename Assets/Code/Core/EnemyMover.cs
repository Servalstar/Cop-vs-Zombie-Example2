using Core.CommonForCharacters;
using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    public class EnemyMover
    {
        private NavMeshAgent _navMeshAgent;
        private Health _health;

        public void Init(NavMeshAgent navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
        }
        
        public void Move(Vector3 targetPosition)
        {
            _navMeshAgent.destination = targetPosition;
        }

        public void Stop()
        {
            _navMeshAgent.ResetPath();
        }
    }
}