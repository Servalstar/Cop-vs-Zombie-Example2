using Core;
using Installers.Common;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.Core
{
    public class EnemyInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _enemy;

        public override void InstallBindings()
        {
            Container.BindAsync<EnemyComponents>().FromMethod(_ => LoadFromPrefab<EnemyComponents>(_enemy));
            //Container.Bind<PlayerFactory>().AsSingle();
            
            //Container.BindInterfacesAndSelfTo<PlayerBehaviour>().AsSingle();
        }
    }
}