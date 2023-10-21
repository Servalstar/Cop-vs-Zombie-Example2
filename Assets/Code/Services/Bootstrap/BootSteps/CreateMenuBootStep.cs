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
        private WindowsFactory _windowsFactory;

        [Inject]
        private void Construct(WindowsFactory windowsFactory)
        {
            _windowsFactory = windowsFactory;
        }
        
        public override async Task<bool> Execute()
        {
            await _windowsFactory.OpenWindow<MainMenuUI>();

            return true;
        }
    }
}