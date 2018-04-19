using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    class Wolf : MonoBehaviour, IAttackable
    {
        Statistics Stats
        {
            get
            {
                return gameObject.GetComponent<Statistics>();
            }
        }

        public float Attack()
        {
            //Basic monster setup
            var attackRate = Stats.Strength;
            return attackRate;
        }
    }
}
