using System;

namespace Core.CommonForCharacters.Contracts
{
    public interface IHealth
    {
        event Action HealthChanged;
        float Max { get; }
        float Current { get; }
    }
}