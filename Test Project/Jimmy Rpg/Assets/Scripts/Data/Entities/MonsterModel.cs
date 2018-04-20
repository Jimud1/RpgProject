using Newtonsoft.Json;
using Assets.Scripts.GameLogic;

namespace Assets.Scripts.Data.Entities
{
    public class MonsterModel : IMonsterModel
    {
        [JsonProperty("monster_id")]
        public int MonsterId { get; set; }
        [JsonProperty("monster_name")]
        public string MonsterName { get; set; }
        [JsonProperty("monster_description")]
        public string MonsterDescription { get; set; }
        public Statistics Statistics { get; set; }
    }
}
