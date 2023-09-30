using Zenject;

namespace Installers.UI
{
    public class UIInstaller : MonoInstaller<UIInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<WindowsFactory>().AsSingle();
            Container.Bind<WindowsController>().AsSingle();
        }
    }
}