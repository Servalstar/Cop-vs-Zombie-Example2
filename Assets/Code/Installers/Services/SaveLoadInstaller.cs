using Services.SaveLoad;
using Zenject;

namespace Installers.Services
{
    public class SaveLoadInstaller : MonoInstaller<SaveLoadInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<JsonSaver>().AsSingle();
            Container.Bind<PlayerProgress>().AsSingle();
        }
    }
}