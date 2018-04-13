using System.Collections.Generic;

namespace Assets.RpgTest
{
    public interface IStoryRepository 
    {
        IEnumerable<StoryModel> Stories { get; }
    }
}
