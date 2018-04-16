using Assets.Scripts.Story;

namespace Assets.Scripts.StoryFlowController
{
    public interface IStoryFlowManager
    {
        StoryModel CurrentStory { get; }
    }
}
