using Services.Bootstrap;
using UnityEngine;
using Zenject;

namespace Installers.Services
{
    public class BootstrapRunnerInstaller : MonoInstaller
    {
        [SerializeField] private BootStepsContainer _bootStepsContainer;

        public override void InstallBindings()
        {
            Container.Bind<BootStepsContainer>().FromInstance(_bootStepsContainer).AsSingle();

            foreach (var bootStep in _bootStepsContainer.InitBootSteps)
            {
                Container.QueueForInject(bootStep);
            }
            
            foreach (var bootStep in _bootStepsContainer.SceneBootSteps)
            {
                Container.QueueForInject(bootStep);
            }
        }
    }
}