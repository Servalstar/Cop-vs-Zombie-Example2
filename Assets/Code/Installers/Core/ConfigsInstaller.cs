using Configs;
using Installers.Common;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.Core
{
    public class ConfigsInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _playerConfig;
        [SerializeField] private AssetReference _enemyConfig;

        public override void InstallBindings()
        {
            Container.BindAsync<PlayerConfig>().FromMethod(_ => LoadComponent<PlayerConfig>(_playerConfig));
            Container.BindAsync<EnemyConfig>().FromMethod(_ => LoadComponent<EnemyConfig>(_enemyConfig));
        }
    }
}