using Core.CommonForCharacters.Contracts;
using UnityEngine;

namespace Core.CommonForCharacters
{
    public class CharacterModel
    {
        public float CurrentSpeed { get; set; }
        public IHealth Health { get; private set; }
        
        public bool IsAlive() => Mathf.Approximately(0, Health.Current) == false;

        public void Init(float maxHealth)
        {
            Health.Init(maxHealth);
        }

        public CharacterModel(IHealth health)
        {
            Health = health;
        }
    }
}