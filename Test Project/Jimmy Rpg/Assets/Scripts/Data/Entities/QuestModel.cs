using Newtonsoft.Json;

namespace Assets.Scripts.Data.Entities
{
    public class QuestModel : IEntity
    {
        [JsonProperty("quest_id")]
        public int QuestId { get; set; }
        [JsonProperty("quest_title")]
        public string QuestTitle { get; set; }
        [JsonProperty("completed")]
        public bool Completed { get; set; }
        [JsonProperty("quest_description")]
        public string QuestDescription { get; set; }
        [JsonProperty("quest_type")]
        public QuestType QuestType { get; set; }
    }

    public enum QuestType
    {
        None = 0,
        EquipEquipment = 1
    }
}
