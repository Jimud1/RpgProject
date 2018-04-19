using Newtonsoft.Json;
namespace Assets.Scripts.Entities
{
    public class QuestModel
    {
        [JsonProperty("quest_id")]
        public int QuestId { get; set; }
        [JsonProperty("completed")]
        public bool Completed { get; set; }
        [JsonProperty("quest_description")]
        public string QuestDescription { get; set; }
    }
}
