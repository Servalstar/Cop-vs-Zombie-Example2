using System.Threading.Tasks;
using Configs;
using Core.CommonForCharacters.Contracts;
using UnityEngine;
using Zenject;

namespace Core.Factories
{
    public class PlayerFactory : ICharacterFactory<PlayerStateMachine>
    {
        private readonly DiContainer _container;
        private readonly SpawnPoints _spawnPoints;
        private readonly CameraMover _cameraMover;
        private readonly Transform _uiRootTransform;

        private Transform _hudRootTransform;

        protected PlayerFactory(DiContainer container, SpawnPoints spawnPoints, CameraMover cameraMover)
        {
            _container = container;
            _spawnPoints = spawnPoints;
            _cameraMover = cameraMover;
        }

        public async Task<PlayerStateMachine> Create() 
        {
            var prefabAsset = _container.Resolve<AsyncInject<PlayerComponents>>();
            var prefab = await prefabAsset;
            
            var playerComponents = _container.InstantiatePrefabForComponent<PlayerComponents>(prefab);
            playerComponents.transform.position = _spawnPoints.PlayerSpawnPoint;
            
            _cameraMover.SetTarget(playerComponents.gameObject);
            
            playerComponents.gameObject.SetActive(true);
            
            var configAsset = _container.Resolve<AsyncInject<PlayerConfig>>();
            var config = await configAsset;

            var playerBehaviour = _container.Resolve<PlayerStateMachine>();
            playerBehaviour.InitStates(playerComponents, config);
            playerBehaviour.ChangeState(CharacterState.Move);

            return playerBehaviour;
        }
    }
}