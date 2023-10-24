using System.Threading;
using System.Threading.Tasks;
using Core;
using Services.Bootstrap.Contracts;
using UnityEngine;
using Zenject;

namespace Services.Bootstrap.BootSteps
{
    [CreateAssetMenu(menuName = "Bootstrap/BootSteps/StartCreatingEnemiesBootStep", fileName = "StartCreatingEnemiesBootStep")]
    public class StartCreatingEnemiesBootStep : BootStep
    {
        private EnemySpawner _spawner;

        [Inject]
        private void Construct(EnemySpawner spawner)
        {
            _spawner = spawner;
        }
        
        public override async Task<bool> Execute()
        {
            var source = new CancellationTokenSource();
            
            await _spawner.Run(source);

            return true;
        }
    }
}