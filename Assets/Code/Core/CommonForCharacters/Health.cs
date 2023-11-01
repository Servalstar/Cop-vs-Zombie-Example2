using System;
using Core.CommonForCharacters.Contracts;
using UnityEngine;

namespace Core.CommonForCharacters
{
    public class Health : IHealth
    {
        private float _maxHealth;

        public event Action HealthChanged;

        public float Max => _maxHealth;
        public float Current { get; private set; }

        public void Init(float maxHealth)
        {
            _maxHealth = maxHealth;
            Current = _maxHealth;
            HealthChanged?.Invoke();
        }

        public void TakeDamage(float damage)
        {
            if (Mathf.Approximately(0, Current) == false)
            {
                Current = Mathf.Clamp(Current - damage, 0, _maxHealth);
                HealthChanged?.Invoke();
            }
        }
    }
}