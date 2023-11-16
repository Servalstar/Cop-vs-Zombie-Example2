using Zenject;

namespace Core.CommonForCharacters.Contracts
{
    public interface ICharacterStateMachine : ITickable
    {
        void ChangeState(CharacterState newState);
    }
}