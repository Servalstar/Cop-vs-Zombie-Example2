using Core.CommonForCharacters.Contracts;
using UnityEngine;

namespace Core.CommonForCharacters
{
    public class Damagable : MonoBehaviour, IDamageable
    {
        public void TakeDamage(float damage)
        {
            Debug.Log(damage);
        }
    }
}