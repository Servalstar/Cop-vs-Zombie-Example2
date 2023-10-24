using System.Collections.Generic;
using System.Threading.Tasks;
using Core.CommonForCharacters.Contracts;

namespace Core
{
    public class ObjectPool<T> where T : IBehaviour
    {
        private readonly ICharacterFactory<T> _factory;
        private readonly Stack<T> _objects = new();

        public ObjectPool(ICharacterFactory<T> factory)
        {
            _factory = factory;
        }

        public int Count => _objects.Count;

        public async Task<IBehaviour> Get()
        {
            if (_objects.Count > 0)
            {
                return _objects.Pop();
            }

            var obj = await _factory.Create();
            
            return obj;
        }

        public void Release(T item)
        {
            _objects.Push(item);
        }
    }
}