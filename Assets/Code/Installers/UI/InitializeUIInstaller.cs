using UI.View;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.UI
{
    public class InitializeUIInstaller : UIBaseInstaller
    {
        [SerializeField] private AssetReference _privacyPrefab;
        [SerializeField] private UiRoot _uiRoot;

        public override void InstallBindings()
        {
            Container.BindAsync<PrivacyWindow>().FromMethod(_ => LoadAsset<PrivacyWindow>(_privacyPrefab)).AsSingle();
            Container.Bind<PrivacyWindowPresenter>().AsSingle();
            Container.Bind<UiRoot>().FromComponentInNewPrefab(_uiRoot).AsSingle();
        }
    }
}