using Zenject;
using Assets.Scripts.Story;
using Assets.Scripts.Npc;

namespace Assets.Scripts
{
    public class IoC : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IRepository>()
                .To<Repository>()
                .AsSingle();

            Container.Bind<StoryService>().AsSingle().NonLazy();

            Container.Bind<IStoryService>()
                .To<StoryService>()
                .AsSingle();

            Container.Bind<ANpc>().AsSingle();
            Container.Bind<cNpc>().AsSingle();
        }
    }
}
