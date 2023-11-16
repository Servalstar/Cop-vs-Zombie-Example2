using System;
using System.Threading;
using System.Threading.Tasks;
using Configs;
using Services;
using Zenject;

namespace Core
{
    public class EnemySpawner
    {
        private readonly ObjectPool<EnemyStateMachine> _enemiesPool;
        private readonly AsyncInject<EnemyConfig> _configAsset;

        private EnemyConfig _config;
        private CancellationTokenSource _source = new();

        public EnemySpawner(
            ObjectPool<EnemyStateMachine> enemiesPool, 
            AsyncInject<EnemyConfig> configAsset,
            GameStateEvents gameStateEvents)
        {
            _enemiesPool = enemiesPool;
            _configAsset = configAsset;

            gameStateEvents.Finish += StopSpawn;
            gameStateEvents.Quite += StopSpawn;
        }

        public async Task Run()
        {
            if (_config == null)
            {
                _config = await _configAsset;
            }

            _source = new CancellationTokenSource();

            StartSpawn(_source.Token);
        }

        private async void StartSpawn(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var enemy = await _enemiesPool.Get();
                enemy.ChangeState(CharacterState.Move);

                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(_config.SpawnCooldown), token);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }

        private void StopSpawn()
        {
            _source.Cancel();
        }
    }
}