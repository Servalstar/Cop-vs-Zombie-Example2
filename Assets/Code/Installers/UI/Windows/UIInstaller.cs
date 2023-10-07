using UI;
using UI.Common;
using UI.Windows.Logic;
using UnityEngine;
using Zenject;

namespace Installers.UI.Windows
{
    public class UIInstaller : MonoInstaller<UIInstaller>
    {
        [SerializeField] private UiRoot _uiRoot;
        
        public override void InstallBindings()
        {
            Container.Bind<WindowsFactory>().AsSingle();
            Container.Bind<WindowsController>().AsSingle();
            Container.Bind<UiRoot>().FromComponentInNewPrefab(_uiRoot).AsSingle();
        }
    }
}