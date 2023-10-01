using System.Threading.Tasks;
using Services.AssetManagement.Contracts;
using Services.Bootstrap.Contracts;
using UnityEngine;
using Zenject;

namespace Services.Bootstrap.BootSteps
{
    [CreateAssetMenu(menuName = "Bootstrap/BootSteps/InitAssetProviderBootStep", fileName = "InitAssetProviderBootStep")]
    public class InitAssetProviderBootStep : BootStep
    {
        private IAssetProvider _assetProvider;

        [Inject]
        private void Construct(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public override async Task<bool> Execute()
        {
            await _assetProvider.Initialize();
            
            return true;
        }
    }
}