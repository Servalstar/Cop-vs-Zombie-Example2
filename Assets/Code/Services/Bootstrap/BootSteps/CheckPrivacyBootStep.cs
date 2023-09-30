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
        private WindowsController _windowsController;

        [Inject]
        private void Construct(WindowsController windowsController)
        {
            _windowsController = windowsController;
        }
        
        public override async Task<bool> Execute()
        {
            var awaiter = new TaskCompletionSource<bool>();
            await _windowsController.Open<PrivacyWindowPresenter, PrivacyWindow>(awaiter);
            await awaiter.Task;
            
            return awaiter.Task.Result;
        }
    }
}