using System.Threading.Tasks;

namespace Core.CommonForCharacters.Contracts
{
    public interface ICharacterFactory<T> where T : IBehaviour
    {
        Task<T> Create();
    }
}