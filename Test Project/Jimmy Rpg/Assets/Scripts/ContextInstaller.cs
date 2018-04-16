using Zenject;
using Assets.Scripts.Story;
using Assets.Scripts.StoryFlowController;
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

            Container.BindInterfacesAndSelfTo<StoryFlowManager>().AsSingle();
        }
    }
}
