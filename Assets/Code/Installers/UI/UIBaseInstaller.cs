using System.Threading.Tasks;
using Services.AssetManagement.Contracts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.UI
{
    public class UIBaseInstaller : MonoInstaller
    {
        private IAssetProvider _assetProvider;

        [Inject]
        public void Construct(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        protected async Task<T> LoadAsset<T> (AssetReference assetReference) where T : Component
        {
            var prefab = await _assetProvider.Load<GameObject>(assetReference);
            
            return prefab.GetComponent<T>();
        }
    }
}