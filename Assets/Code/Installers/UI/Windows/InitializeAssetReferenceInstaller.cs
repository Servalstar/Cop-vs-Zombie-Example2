using Installers.Common;
using UI.Views;
using UI.Windows.Presenters;
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
            Container.BindAsync<PrivacyView>().FromMethod(_ => LoadAsset<PrivacyView>(_privacyPrefab)).AsSingle();
            Container.BindInterfacesTo<PrivacyWindowPresenter>().AsSingle();
        }
    }
}