using UnityEngine;

namespace Assets.Scripts.GameLogic.Models
{
    public class GameStats : MonoBehaviour, IStatistical
    {
        public float MaxHp { get; set; }

        public float? CurrentHp { get; set; }
        public float Strength { get; set; }
    }
}
