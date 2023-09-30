using UnityEngine;
using Zenject;

namespace Installers.UI
{
    public class UIInstaller : MonoInstaller<UIInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<WindowFactory>().AsSingle();
            Container.Bind<WindowController>().AsSingle();
            Debug.Log("Bind WindowController");
        }
    }
}