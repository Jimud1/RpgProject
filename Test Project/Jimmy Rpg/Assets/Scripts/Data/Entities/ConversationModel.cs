using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assets.Scripts.Data.Entities
{
    /// <summary>
    ///Conversation for Dialog
    /// </summary>
    [Serializable]
    public class ConversationModel : IEntity
    {
        [JsonProperty("conversation_id")]
        public int ConversationId { get; set; }

        [JsonProperty("conversation_text")]
        public string ConversationText { get; set; }

        [JsonProperty("conversation_options")]
        public IDictionary<string, int?> ConversationOptions { get; set; }
    }
}

