using System.Collections.Generic;

namespace Assets.StoryController
{
    public interface IStoryRepository 
    {
        IEnumerable<StoryModel> Stories { get; }
    }
}
