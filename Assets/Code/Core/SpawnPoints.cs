using UnityEngine;

namespace Core
{
    public class SpawnPoints : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Transform _enemiesSpawnPoint;

        public Vector3 PlayerSpawnPoint => _playerSpawnPoint.position;
        public Vector3 EnemiesSpawnPoint => _enemiesSpawnPoint.position;
    }
}