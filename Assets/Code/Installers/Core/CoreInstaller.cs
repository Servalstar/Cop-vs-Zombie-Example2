using Core;
using Installers.Common;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.Core
{
    public class CoreInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _player;
        [SerializeField] private CameraMover _cameraMover;

        public override void InstallBindings()
        {
            Container.BindAsync<Player>().FromMethod(_ => LoadAsset<Player>(_player));
            Container.Bind<PlayerFactory>().AsSingle();
            Container.Bind<CameraMover>().FromInstance(_cameraMover).AsSingle();
        }
    }
}