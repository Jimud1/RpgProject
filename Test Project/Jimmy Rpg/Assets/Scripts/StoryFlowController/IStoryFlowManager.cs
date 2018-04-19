using Assets.Scripts.Entities;

namespace Assets.Scripts.StoryFlowController
{
    public interface IStoryFlowManager
    {
        bool Conversing { get; }
        StoryModel CurrentStory { get; }
        void FillCanvas();
    }
}
