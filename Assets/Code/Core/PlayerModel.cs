using Core.CommonForCharacters;
using Core.CommonForCharacters.Contracts;
using UnityEngine;

namespace Core
{
    public class PlayerModel : CharacterModel
    {
        public int CurrentScore { get; set; }
        public Transform Transform { get; set; }

        public PlayerModel(IHealth health) : base(health)
        {
        }
    }
}