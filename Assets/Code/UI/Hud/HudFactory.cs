using System.Threading.Tasks;
using Services.Input;
using Services.Input.Contracts;
using UI.Common;
using UnityEngine;
using Zenject;

namespace UI.Windows.Logic
{
    public class HudFactory
    {
        private const string HUD = "HUD";
        
        private readonly DiContainer _container;
        private readonly Transform _uiRootTransform;

        private Transform _hudRootTransform;

        protected HudFactory(DiContainer container, UiRoot uiRootTransform)
        {
            _container = container;
            _uiRootTransform = uiRootTransform.transform;
        }
        
        public async Task CreateHudRoot()
        {
            var asset = _container.Resolve<AsyncInject<Hud>>();
            var prefab = await asset;
            
            var hud = Object.Instantiate(prefab, _uiRootTransform);
            _hudRootTransform = hud.transform;
        }

        public async Task CreateInput() 
        {
            var asset = _container.Resolve<AsyncInject<Joystick>>();
            var input = _container.Resolve<IInputService>();
            var prefab = await asset;
            
            var joystick = Object.Instantiate(prefab, _hudRootTransform);
            input.SetJoystick(joystick);
        }
    }
}