using Core.CommonForCharacters;
using Core.CommonForCharacters.Contracts;

namespace Core
{
    public class PlayerModel : CharacterModel
    {
        public int CurrentScore { get; set; }

        public PlayerModel(IHealth health) : base(health)
        {
        }
    }
}