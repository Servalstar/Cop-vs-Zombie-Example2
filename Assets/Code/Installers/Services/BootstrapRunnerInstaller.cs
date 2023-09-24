using Services.Bootstrap.BootSteps;
using Services.Bootstrap.Contracts;
using UnityEngine;
using Zenject;

namespace Installers.Services
{
    public class BootstrapRunnerInstaller : MonoInstaller<BootstrapRunnerInstaller>
    {
        [SerializeField] private BootStepsContainer _bootStepsContainer;
        [Inject] private IBootstrapService _bootstrapService;
        
        public override void InstallBindings()
        {
            if (_bootstrapService.IsExecuted)
            {
                return;
            }
            
            Container.Bind<BootStepsContainer>().FromInstance(_bootStepsContainer).AsSingle();

            foreach (var bootStep in _bootStepsContainer.BootSteps)
            {
                Container.QueueForInject(bootStep);
            }
        }
    }
}