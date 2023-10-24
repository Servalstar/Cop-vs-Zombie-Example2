using System.Threading.Tasks;
using Services.AssetManagement.Contracts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.Common
{
    public class BaseAssetReferenceInstaller : MonoInstaller
    {
        private IAssetProvider _assetProvider;

        [Inject]
        public void Construct(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        protected async Task<T> LoadFromPrefab<T> (AssetReference assetReference)
        {
            var prefab = await _assetProvider.Load<GameObject>(assetReference);
            
            return prefab.GetComponent<T>();
        }
        
        protected async Task<T> LoadComponent<T> (AssetReference assetReference) where T : class
        {
            return await _assetProvider.Load<T>(assetReference);
        }
    }
}