using System;
using Services.Bootstrap.BootSteps;
using Services.Bootstrap.Contracts;

namespace Services.Bootstrap
{
    public class BootstrapService : IBootstrapService
    {
        public bool IsExecuted { get; private set; }
        
        public async void Execute(BootStepsContainer bootStepsContainer)
        {
            IsExecuted = true;
            
            foreach (var bootStep in bootStepsContainer.BootSteps)
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