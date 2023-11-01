using Core.CommonForCharacters;
using Zenject;

namespace Installers.Core
{
    public class CharacterCommonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Health>().AsTransient();
            Container.Bind<CharacterModel>().AsTransient();
            Container.Bind<CharacterAnimator>().AsTransient();
        }
    }
}