using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Core/EnemyConfig", fileName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _stopDistance;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _spawnCooldown;
        [Header("Attack data")]
        [SerializeField] private float _damage;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _attackRadius;


        public float MovementSpeed => _movementSpeed;
        public float StopDistance => _stopDistance;

        public float MaxHealth => _maxHealth;

        public float Damage => _damage;

        public float AttackCooldown => _attackCooldown;

        public float AttackRadius => _attackRadius;
        public float SpawnCooldown => _spawnCooldown;
    }
}