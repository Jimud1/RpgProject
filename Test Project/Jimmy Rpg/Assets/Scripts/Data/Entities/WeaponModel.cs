using Newtonsoft.Json;
namespace Assets.Scripts.Data.Entities
{
    public class WeaponModel : IWeapon
    {
        [JsonProperty("item_id")]
        public int ItemId { get; set; }
        public float Attack { get; set; }
        [JsonProperty("item_name")]
        public string ItemName { get; set; }
        [JsonProperty("item_value")]
        public decimal ItemValue { get; set; }     
    }
}