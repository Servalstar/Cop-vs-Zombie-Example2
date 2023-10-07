using System;
using System.Threading.Tasks;
using Services.Bootstrap.Contracts;

namespace Services.Bootstrap
{
    public class BootstrapService : IBootstrapService
    {
        public bool IsInitialized { get; private set; }
        
        public async void Execute(BootStepsContainer bootStepsContainer)
        {
            if (!IsInitialized)
            {
                await ExecuteBootSteps(bootStepsContainer.InitBootSteps);
                
                IsInitialized = true;
            }
            
            await ExecuteBootSteps(bootStepsContainer.SceneBootSteps);
        }

        private static async Task ExecuteBootSteps(BootStep[] bootSteps)
        {
            foreach (var bootStep in bootSteps)
            {
                var isSuccessful = await bootStep.Execute();

                if (!isSuccessful)
                {
                    throw new Exception($"BootStep's {bootStep.GetType()} execution failed");
                }
            }
        }
    }
}