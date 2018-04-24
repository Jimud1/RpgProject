using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class Statistics : IStatistical
    {
        public float Strength { get; set; }
        [JsonProperty("max_hp")]
        public float MaxHp { get; set; }
        [JsonProperty("current_hp")]
        public float? CurrentHp { get; set; }
        //public float Dexterity { get; set; }
        //public float Accuracy { get; set; }
        //public float Constitution { get; set; }
        //public float Intelligence { get; set; }
        //public float Wisdom { get; set; }
    }
}
