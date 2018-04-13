using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assets.StoryController
{
    /// <summary>
    /// Story start
    /// </summary>
    [Serializable]
    public class StoryModel 
    {
        [JsonProperty("story_id")]
        public int StoryId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public IList<ConversationModel> Conversations { get; set; }
    }
}