using Services.Input;
using Zenject;

namespace Installers.Services
{
    public class InputInstaller : MonoInstaller<InputInstaller>
    {
        public override void InstallBindings()
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            Container.BindInterfacesTo<StandaloneInputService>().AsSingle();
#else
            Container.BindInterfacesTo<MobileInputService>().AsSingle();
#endif
        }
    }
}