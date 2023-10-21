using System.Threading.Tasks;
using Services.Input;
using Services.Input.Contracts;
using UI.Common;
using UnityEngine;
using Zenject;

namespace Core
{
    public class PlayerFactory
    {
        private const string HUD = "HUD";
        
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

        public async Task Create() 
        {
            var asset = _container.Resolve<AsyncInject<Player>>();
            var prefab = await asset;
            
            var player = Object.Instantiate(prefab);
            player.transform.position = _spawnPoints.PlayerSpawnPoint;
            
            _cameraMover.SetTarget(player.gameObject);
            
            player.gameObject.SetActive(true);
        }
    }
}