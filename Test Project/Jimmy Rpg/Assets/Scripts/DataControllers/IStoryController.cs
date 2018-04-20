using Assets.Scripts.Data.Entities;

namespace Assets.Scripts.DataControllers
{ 
    public interface IStoryController
    {
        bool Conversing { get; }
        StoryModel CurrentStory { get; }
        void FillCanvas();
    }
}
