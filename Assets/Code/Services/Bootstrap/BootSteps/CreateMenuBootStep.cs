using System.Threading.Tasks;
using Services.Bootstrap.Contracts;
using UI.MainMenu;
using UI.Windows.Logic;
using UnityEngine;
using Zenject;

namespace Services.Bootstrap.BootSteps
{
    [CreateAssetMenu(menuName = "Bootstrap/BootSteps/CreateMenuBootStep", fileName = "CreateMenuBootStep")]
    public class CreateMenuBootStep : BootStep
    {
        private WindowsFactory _windowsController;

        [Inject]
        private void Construct(WindowsFactory windowsFactory)
        {
            _windowsController = windowsFactory;
        }
        
        public override async Task<bool> Execute()
        {
            var presenter = await _windowsController.GetWindow<MainMenuPresenter, MainMenuUI>();
            presenter.Open();

            return true;
        }
    }
}