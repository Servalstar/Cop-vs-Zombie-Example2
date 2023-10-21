using Installers.Common;
using UI.Common;
using UI.Windows.Logic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.UI.Core
{
    public class HudInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _hud;

        public override void InstallBindings()
        {
            Container.BindAsync<Hud>().FromMethod(_ => LoadAsset<Hud>(_hud));
            Container.Bind<HudFactory>().AsSingle();
        }
    }
}