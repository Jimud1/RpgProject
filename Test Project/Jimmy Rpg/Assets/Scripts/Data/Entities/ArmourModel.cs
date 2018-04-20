using Newtonsoft.Json;
namespace Assets.Scripts.Data.Entities
{
    public class ArmourModel : IArmour
    {
        [JsonProperty("item_id")]
        public int ItemId { get; set; }
        [JsonProperty("item_name")]
        public string ItemName { get; set; }
        [JsonProperty("item_description")]
        public string ItemDescription { get; set; }
        [JsonProperty("item_value")]
        public decimal ItemValue { get; set; }
        public float Defense { get; set; } 
    }
}
