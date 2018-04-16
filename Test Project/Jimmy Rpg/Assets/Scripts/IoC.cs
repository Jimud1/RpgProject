using Zenject;
using Assets.Scripts.Story;
using Assets.Scripts.NonPlayerCharacter;
using UnityEngine;

namespace Assets.Scripts
{
    public class IoC : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Installing Bindings");

            Container.Bind<IRepository>()
                .To<Repository>()
                .AsSingle().NonLazy();

            Container.Bind<IStoryService>()
                .To<StoryService>()
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<Npc>().AsSingle();
        }
    }
}
