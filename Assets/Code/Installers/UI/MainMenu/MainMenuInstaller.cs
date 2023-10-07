using Installers.Common;
using UI;
using UI.MainMenu;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.UI.MainMenu
{
    public class MainMenuInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _mainMenuPrefab;
        [SerializeField] private UiRoot _uiRoot;

        public override void InstallBindings()
        {
            Container.BindAsync<MainMenuUI>().FromMethod(_ => LoadAsset<MainMenuUI>(_mainMenuPrefab)).AsSingle();
            Container.Bind<UiRoot>().FromComponentInNewPrefab(_uiRoot).AsSingle();
        }
    }
}