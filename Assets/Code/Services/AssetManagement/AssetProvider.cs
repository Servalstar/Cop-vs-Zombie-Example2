using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.AssetManagement.Contracts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new();

        public async Task Initialize()
        {
            await Addressables.InitializeAsync().Task;
        }

        public async Task<T> Load<T>(string address) where T : class
        {
            if (_completedCache.TryGetValue(address, out AsyncOperationHandle completedHandle))
            {
                return completedHandle.Result as T;
            }
            
            return await RunWithCacheOnComplete(Addressables.LoadAssetAsync<T>(address), cacheKey: address);
        }

        public async Task<T> Load<T>(AssetReference assetReference) where T : class
        {
            if (_completedCache.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
            {
                return completedHandle.Result as T;
            }

            return await RunWithCacheOnComplete(Addressables.LoadAssetAsync<T>(assetReference), cacheKey: assetReference.AssetGUID);
        }

        public Task<GameObject> Instantiate(string address)
        {
            return Addressables.InstantiateAsync(address).Task;
        }

        public Task<GameObject> Instantiate(string address, GameObject parent)
        {
            return Addressables.InstantiateAsync(address, parent.transform).Task;
        }

        public void Cleanup()
        {
            foreach (var handle in _handles.Values.SelectMany(resourceHandles => resourceHandles))
            {
                Addressables.Release(handle);
            }
            
            _completedCache.Clear();
            _handles.Clear();
        }

        private async Task<T> RunWithCacheOnComplete<T>(AsyncOperationHandle<T> handle, string cacheKey) where T : class
        {
            handle.Completed += completeHandle => _completedCache[cacheKey] = completeHandle;

            AddHandle(cacheKey, handle);

            return await handle.Task;
        }

        private void AddHandle(string key, AsyncOperationHandle handle)
        {
            if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                _handles[key] = resourceHandles;
            }

            resourceHandles.Add(handle);
        }
    }
}