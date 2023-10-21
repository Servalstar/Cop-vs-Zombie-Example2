using Installers.Common;
using UI.Views;
using UI.Windows.Presenters;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.UI.Windows
{
    public class PrivacyInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _privacyPrefab;

        public override void InstallBindings()
        {
            Container.BindAsync<PrivacyView>().FromMethod(_ => LoadAsset<PrivacyView>(_privacyPrefab));
            Container.BindInterfacesTo<PrivacyWindowPresenter>().AsSingle();
        }
    }
}