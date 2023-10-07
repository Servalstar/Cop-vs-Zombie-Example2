using Services.Bootstrap;
using Services.Bootstrap.Contracts;
using UnityEngine;
using Zenject;

namespace Installers.Services
{
    public class BootstrapRunnerInstaller : MonoInstaller
    {
        [SerializeField] private BootStepsContainer _bootStepsContainer;
        [Inject] private IBootstrapService _bootstrapService;
        
        public override void InstallBindings()
        {
            Container.Bind<BootStepsContainer>().FromInstance(_bootStepsContainer).AsSingle();

            if (_bootstrapService.IsExecuted)
            {
                return;
            }
            
            foreach (var bootStep in _bootStepsContainer.BootSteps)
            {
                Container.QueueForInject(bootStep);
            }
        }
    }
}