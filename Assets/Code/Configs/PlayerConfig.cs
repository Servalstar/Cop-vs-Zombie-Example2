using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Core/PlayerConfig", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _maxHealth;
        [Header("Attack data")]
        [SerializeField] private float _damage;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _attackRadius;


        public float MovementSpeed => _movementSpeed;

        public float MaxHealth => _maxHealth;

        public float Damage => _damage;

        public float Cooldown => _cooldown;

        public float AttackRadius => _attackRadius;
    }
}