using Core;
using UnityEngine;
using Zenject;

namespace Installers.Core
{
    public class SpawnPointsInstaller : MonoInstaller
    {
        [SerializeField] private SpawnPoints _spawnPoints;
        
        public override void InstallBindings()
        {
            Container.Bind<SpawnPoints>().FromInstance(_spawnPoints);
        }
    }
}