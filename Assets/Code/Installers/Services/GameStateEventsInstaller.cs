using Services;
using Zenject;

namespace Installers.Services
{
    public class GameStateEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateEvents>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}
