using System;
using System.Collections.Generic;

namespace Assets.StoryController
{
    [Serializable]
    public class JsonStory
    {
        public IEnumerable<StoryModel> Stories { get; set; }
    }
}
