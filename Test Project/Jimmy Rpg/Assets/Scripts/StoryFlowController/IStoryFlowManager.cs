using Assets.Scripts.Story;

namespace Assets.Scripts.StoryFlowController
{
    public interface IStoryFlowManager
    {
        void Converse();
        StoryModel CurrentStory { get; }
        int NpcStoryId { get; }
    }
}
