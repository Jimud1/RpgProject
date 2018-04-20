using Zenject;
using Assets.Scripts.Data;
using Assets.Scripts.DataControllers;
using Assets.Scripts.Services;

namespace Assets.Scripts
{
    public class ContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IRepository>()
                .To<Repository>()
                .AsSingle().NonLazy();

            Container.Bind<IStoryService>()
                .To<StoryService>()
                .AsSingle().NonLazy();

            Container.Bind<IWeaponService>()
                .To<WeaponService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<StoryController>().AsSingle();

        }
    }
}
