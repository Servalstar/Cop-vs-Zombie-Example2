using System;
using System.Threading;
using System.Threading.Tasks;
using Configs;
using Zenject;

namespace Core
{
    public class EnemySpawner
    {
        private readonly ObjectPool<EnemyBehaviour> _enemiesPool;
        private readonly AsyncInject<EnemyConfig> _configAsset;
        
        private EnemyConfig _config;

        public EnemySpawner(ObjectPool<EnemyBehaviour> enemiesPool, AsyncInject<EnemyConfig> configAsset)
        {
            _enemiesPool = enemiesPool;
            _configAsset = configAsset;
        }

        public async Task Run(CancellationTokenSource source)
        {
            if (_config == null)
            {
                _config = await _configAsset;
            }
        
            while (!source.Token.IsCancellationRequested)
            {
                var enemy = await _enemiesPool.Get();
                enemy.Activate();

                await Task.Delay(TimeSpan.FromSeconds(_config.SpawnCooldown), source.Token);
            }
        }
    }
}