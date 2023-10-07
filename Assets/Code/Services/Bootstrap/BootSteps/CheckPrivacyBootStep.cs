using System.Threading.Tasks;
using Services.Bootstrap.Contracts;
using Services.SaveLoad;
using Services.SaveLoad.Contracts;
using UI.Presenters;
using UI.Views;
using UI.Windows.Logic;
using UnityEngine;
using Zenject;

namespace Services.Bootstrap.BootSteps
{
    [CreateAssetMenu(menuName = "Bootstrap/BootSteps/CheckPrivacyBootStep", fileName = "CheckPrivacyBootStep")]
    public class CheckPrivacyBootStep : BootStep
    {
        private WindowsController _windowsController;
        private ISaver _saver;

        [Inject]
        private void Construct(ISaver saver, WindowsController windowsController)
        {
            _saver = saver;
            _windowsController = windowsController;
        }
        
        public override async Task<bool> Execute()
        {
            var privacyState = _saver.Load<PrivacyState>();

            if (privacyState.IsAccepted)
            {
                return true;
            }
            
            var awaiter = new TaskCompletionSource<bool>();
            await _windowsController.Open<PrivacyWindowPresenter, PrivacyWindow>(awaiter);
            var result = await awaiter.Task;

            privacyState.IsAccepted = result;
            _saver.Save(privacyState);
            
            return result;
        }
    }
}