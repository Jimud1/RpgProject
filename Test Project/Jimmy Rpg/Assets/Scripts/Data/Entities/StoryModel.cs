using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Assets.Scripts.Data.Entities
{
    /// <summary>
    /// Story start
    /// </summary>
    [Serializable]
    public class StoryModel : IEntity
    {
        [JsonProperty("story_id")]
        public int StoryId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public IList<ConversationModel> Conversations { get; set; }
        [JsonProperty("quest_concerning")]
        public int? QuestConcerning { get; set; }
    }
}