using System.Threading.Tasks;
using Configs;
using Core.CommonForCharacters.Contracts;
using UnityEngine;
using Zenject;

namespace Core.Factories
{
    public class EnemyFactory : ICharacterFactory<EnemyBehaviour>
    {
        private readonly DiContainer _container;
        private readonly SpawnPoints _spawnPoints;
        private readonly TickableManager _tickableManager;
        private readonly Transform _uiRootTransform;

        private Transform _hudRootTransform;

        protected EnemyFactory(DiContainer container, SpawnPoints spawnPoints, TickableManager tickableManager)
        {
            _container = container;
            _spawnPoints = spawnPoints;
            _tickableManager = tickableManager;
        }

        public async Task<EnemyBehaviour> Create() 
        {
            var prefabAsset = _container.Resolve<AsyncInject<EnemyComponents>>();
            var prefab = await prefabAsset;
            
            var enemyComponents = _container.InstantiatePrefabForComponent<EnemyComponents>(prefab);
            enemyComponents.transform.position = _spawnPoints.EnemiesSpawnPoint;
            
            enemyComponents.gameObject.SetActive(true);
            
            var configAsset = _container.Resolve<AsyncInject<EnemyConfig>>();
            var config = await configAsset;

            var enemyBehaviour = _container.Resolve<EnemyBehaviour>();

            enemyBehaviour.Init(enemyComponents, config);
            enemyBehaviour.Activate();
            _tickableManager.Add(enemyBehaviour);
            return enemyBehaviour;
        }
    }
}