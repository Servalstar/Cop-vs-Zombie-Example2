using Core;
using Installers.Common;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.Core
{
    public class CorePrefabsInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _player;

        public override void InstallBindings()
        {
            Container.BindAsync<Player>().FromMethod(_ => LoadAsset<Player>(_player));
            Container.Bind<PlayerFactory>().AsSingle();
        }
    }
}