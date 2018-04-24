using Newtonsoft.Json;
using Assets.Scripts.GameLogic;

namespace Assets.Scripts.Data.Entities
{
    public class MonsterEntity : IMonsterModel
    {
        [JsonProperty("monster_id")]
        public int MonsterId { get; set; }
        [JsonProperty("monster_name")]
        public string MonsterName { get; set; }
        [JsonProperty("monster_description")]
        public string MonsterDescription { get; set; }
        public Statistics Statistics { get; set; }
        [JsonProperty("monster_prefab")]
        public string PrefabPath { get; set; }
    }
}
