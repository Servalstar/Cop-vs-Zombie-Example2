using Services.Bootstrap.Contracts;
using UnityEngine;
using Zenject;

namespace Services.Bootstrap
{
    public class BootstrapRunner : MonoBehaviour
    {
        private IBootstrapService _bootstrapService;
        private BootStepsContainer _bootStepsContainer;
        
        [Inject]
        private void Construct(IBootstrapService bootstrapService, BootStepsContainer bootStepsContainer)
        {
            _bootStepsContainer = bootStepsContainer;
            _bootstrapService = bootstrapService;
        } 
        
        private void Awake()
        {
            _bootstrapService.Execute(_bootStepsContainer);
        }
    }
}