using Installers.Common;
using Services.Input;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers.Services
{
    public class InputInstaller : BaseAssetReferenceInstaller
    {
        [SerializeField] private AssetReference _joystick;
        
        public override void InstallBindings()
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            Container.BindInterfacesTo<StandaloneInputService>().AsSingle();
#else
            Container.BindInterfacesTo<MobileInputService>().AsSingle();
#endif
            
            Container.BindAsync<Joystick>().FromMethod(_ => LoadAsset<Joystick>(_joystick));
        }
    }
}