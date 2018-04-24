using UnityEngine;

namespace Assets.Scripts.GameLogic.Models
{
    public class MonsterGameModel : MonoBehaviour
    {
        public int MonsterId { get; set; }
        public GameObject Enemy { get; set; }
        public Statistics Statistics { get; set; }
        public string MonsterName { get; set; }
        public string MonsterDescription { get; set; }
    }
}
