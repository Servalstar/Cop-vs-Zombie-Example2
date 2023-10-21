using System.Threading.Tasks;
using Services.Bootstrap.Contracts;
using UI.Windows.Logic;
using UnityEngine;
using Zenject;

namespace Services.Bootstrap.BootSteps
{
    [CreateAssetMenu(menuName = "Bootstrap/BootSteps/CreateHudBootStep", fileName = "CreateHudBootStep")]
    public class CreateHudBootStep : BootStep
    {
        private HudFactory _hudFactory;

        [Inject]
        private void Construct(HudFactory hudFactory)
        {
            _hudFactory = hudFactory;
        }
        
        public override async Task<bool> Execute()
        {
            await _hudFactory.CreateHudRoot();
            await _hudFactory.CreateInput();

            return true;
        }
    }
}