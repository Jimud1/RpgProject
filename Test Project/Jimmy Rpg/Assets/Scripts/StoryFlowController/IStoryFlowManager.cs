using Assets.Scripts.Story;
using UnityEngine;

namespace Assets.Scripts.StoryFlowController
{
    public interface IStoryFlowManager
    {
        StoryModel CurrentStory { get; }
        void FillCanvas(GameObject canvas);
    }
}
