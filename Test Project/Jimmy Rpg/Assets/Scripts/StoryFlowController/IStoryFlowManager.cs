using Assets.Scripts.Story;

namespace Assets.Scripts.StoryFlowController
{
    public interface IStoryFlowManager
    {
        bool Conversing { get; }
        StoryModel CurrentStory { get; }
        void FillCanvas();
    }
}
