
using Assets.Scripts.GameLogic;

namespace Assets.Scripts.Data.Entities
{
    public class MonsterModel : IMonsterModel
    {
        public string MonsterName { get; set; }
        public string MonsterDescription { get; set; }
        public Statistics Statistics { get; set; }
    }
}
