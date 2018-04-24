using Assets.Scripts.GameLogic;
using UnityEngine;

namespace Assets.Scripts.GameLogic.Models
{ 

    public class PlayerGameModel : MonoBehaviour
    {
        
        #region Properties
        //Will load stats from a file
        Statistics PlayerStats;
        //Will get loaded from a file
        Equipment EquippedEquipment;
        Levelable CurrentLevel;
        public bool IsDead
        {
            get
            {
                return PlayerStats.CurrentHp > 0;
            }
        }
        #endregion
    }
}