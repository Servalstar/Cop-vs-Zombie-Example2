using System.Threading.Tasks;
using Services.Bootstrap.Contracts;
using UI.View;
using UnityEngine;
using Zenject;

namespace Services.Bootstrap.BootSteps
{
    [CreateAssetMenu(menuName = "Bootstrap/BootSteps/CheckPrivacyBootStep", fileName = "CheckPrivacyBootStep")]
    public class CheckPrivacyBootStep : BootStep
    {
        private WindowController _windowController;

        [Inject]
        private void Construct(WindowController windowController)
        {
            _windowController = windowController;
        }
        
        public override async Task<bool> Execute()
        {
            await _windowController.Open<PrivacyWindowPresenter, PrivacyWindow>();

            return await Task.FromResult(true);
        }
    }
}