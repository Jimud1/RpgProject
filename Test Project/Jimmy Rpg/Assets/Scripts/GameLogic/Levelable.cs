using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class Levelable : MonoBehaviour, ILevelable
    {
        private LevelModel _level;
        public LevelModel Level
        {
            get
            {
                return _level ?? (_level = new LevelModel {Level = 1, Experience = 0 });
            }
        }

        public void AddExperience(float exp)
        {
            _level.Experience += exp;
        }

        public void LevelUp()
        {
            _level.Level++;
        }
    }
}
