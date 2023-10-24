using System.Threading.Tasks;
using Core.Factories;
using Services.Bootstrap.Contracts;
using UnityEngine;
using Zenject;

namespace Services.Bootstrap.BootSteps
{
    [CreateAssetMenu(menuName = "Bootstrap/BootSteps/CreatePlayerBootStep", fileName = "CreatePlayerBootStep")]
    public class CreatePlayerBootStep : BootStep
    {
        private PlayerFactory _playerFactory;

        [Inject]
        private void Construct(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public override async Task<bool> Execute()
        {
            await _playerFactory.Create();

            return true;
        }
    }
}