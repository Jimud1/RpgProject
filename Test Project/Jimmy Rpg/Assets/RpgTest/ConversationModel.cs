using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assets.RpgTest
{
    /// <summary>
    ///Conversation for Dialog
    /// </summary>
    [Serializable]
    public class ConversationModel 
    {
        [JsonProperty("conversation_id")]
        public int ConversationId { get; set; }

        [JsonProperty("conversation_text")]
        public string ConversationText { get; set; }

        [JsonProperty("conversation_options")]
        public IList<string> ConversationOptions { get; set; }

        [JsonProperty("story_lead_id")]
        public int? StoryLeadId { get; set; }
    }
}

