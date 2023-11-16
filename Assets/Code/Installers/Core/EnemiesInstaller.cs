using Core;
using Core.Factories;
using Installers.Common;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.Core
{
    public class EnemiesInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _enemy;

        public override void InstallBindings()
        {
            Container.BindAsync<EnemyComponents>().FromMethod(_ => LoadFromPrefab<EnemyComponents>(_enemy));
            
            Container.Bind<ObjectPool<EnemyStateMachine>>().AsSingle();
            Container.BindInterfacesTo<EnemyFactory>().AsSingle();
            Container.Bind<EnemySpawner>().AsSingle();
            
            Container.Bind<EnemyMover>().AsTransient();
            Container.Bind<EnemyStateMachine>().AsTransient();
        }
    }
}