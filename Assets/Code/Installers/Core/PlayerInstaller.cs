using Core;
using Core.Factories;
using Installers.Common;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.Core
{
    public class PlayerInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _player;
        [SerializeField] private CameraMover _cameraMover;

        public override void InstallBindings()
        {
            Container.BindAsync<PlayerComponents>().FromMethod(_ => LoadFromPrefab<PlayerComponents>(_player));
            Container.BindInterfacesTo<PlayerFactory>().AsSingle();
            
            Container.Bind<PlayerMoveState>().AsTransient();
            Container.Bind<PlayerAttackState>().AsTransient();
            Container.Bind<PlayerDeathState>().AsTransient();
            Container.Bind<PlayerModel>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle();

            Container.Bind<CameraMover>().FromInstance(_cameraMover).AsSingle();
        }
    }
}