using UnityEngine;
namespace Assets.Scripts.GameLogic
{
    public class Statistics : MonoBehaviour,  IStatistical
    {
        public float Strength { get; set; }
        public float Dexterity { get; set; }
        public float Accuracy { get; set; }
        public float Constitution { get; set; }
        public float Intelligence { get; set; }
        public float Wisdom { get; set; }
        public float MaxHp { get; set; }
        public float CurrentHp { get; set; }
    }
}
