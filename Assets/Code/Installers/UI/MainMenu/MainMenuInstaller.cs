using Installers.Common;
using UI.MainMenu;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.UI.MainMenu
{
    public class MainMenuInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _mainMenuPrefab;

        public override void InstallBindings()
        {
            Container.BindAsync<MainMenuUI>().FromMethod(_ => LoadAsset<MainMenuUI>(_mainMenuPrefab)).AsSingle();
            Container.Bind<MainMenuPresenter>().AsSingle();
        }
    }
}