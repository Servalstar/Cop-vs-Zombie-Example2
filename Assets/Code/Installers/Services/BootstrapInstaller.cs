using Services.Bootstrap;
using Zenject;

namespace Installers.Services
{
    public class BootstrapInstaller : MonoInstaller<BootstrapInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BootstrapService>().AsSingle();
        }
    }
}