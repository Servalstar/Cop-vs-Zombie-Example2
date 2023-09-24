using Services.Bootstrap.BootSteps;

namespace Services.Bootstrap.Contracts
{
    public interface IBootstrapService
    {
        void Execute(BootStepsContainer bootStepsContainer);
    }
}