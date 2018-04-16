using System.Collections.Generic;
using Assets.Scripts.Story;

namespace Assets.Scripts
{
    public interface IRepository 
    {
        IEnumerable<StoryModel> Stories { get; }
    }
}
