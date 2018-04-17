using Zenject;
using Assets.Scripts.Story;
using Assets.Scripts.StoryFlowController;
using Assets.Scripts.PlayerControls;
using UnityEngine;

namespace Assets.Scripts
{
    public class ContextInstaller : MonoInstaller
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

            Container.Bind<IMoveable>()
                .To<Moveable>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<StoryFlowManager>().AsSingle();
        }
    }
}
