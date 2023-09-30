using System.Threading.Tasks;
using Services.AssetManagement.Contracts;
using UI.View;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.UI
{
    public class InitializeUIInstaller : UIBaseInstaller
    {
        [SerializeField] private AssetReference _privacyPrefab;

        public override void InstallBindings()
        {
            Container.BindAsync<PrivacyWindow>().FromMethod(_ => LoadAsset<PrivacyWindow>(_privacyPrefab)).AsSingle();
            Container.Bind<PrivacyWindowPresenter>().AsSingle();
            Debug.Log("Bind presenter");
        }
    }
    
    public class UIBaseInstaller : MonoInstaller
    {
        private IAssetProvider _assetProvider;

        [Inject]
        public void Construct(IAssetProvider assetProvider)
        {
            Debug.Log("InitializeUIInstaller " + assetProvider);
            _assetProvider = assetProvider;
        }

        protected async Task<T> LoadAsset<T> (AssetReference assetReference) where T : Component
        {
            var prefab = await _assetProvider.Load<GameObject>(assetReference);
            
            return prefab.GetComponent<T>();
        }
    }
}