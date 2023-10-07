using Installers.Common;
using UI.Presenters;
using UI.Views;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.UI.Windows
{
    public class InitializeAssetReferenceInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _privacyPrefab;

        public override void InstallBindings()
        {
            Container.BindAsync<PrivacyWindow>().FromMethod(_ => LoadAsset<PrivacyWindow>(_privacyPrefab)).AsSingle();
            Container.Bind<PrivacyWindowPresenter>().AsSingle();
        }
    }
}