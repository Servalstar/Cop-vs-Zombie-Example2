using Services.AssetManagement;
using Zenject;

namespace Installers.Services
{
    public class AssetManagementInstaller : MonoInstaller<AssetManagementInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AssetProvider>().AsSingle();
        }
    }
}