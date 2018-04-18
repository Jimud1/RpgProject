using Assets.Scripts.GameLogic;
using UnityEngine;

namespace Assets.Scripts.PlayerControls
{
    public class Player : MonoBehaviour
    {
        
        #region Properties
        Statistics PlayerStats;
        Equipment EquippedEquipment;
        Levelable CurrentLevel;
        #endregion

        /// <summary>
        /// Unity Constructor
        /// </summary>
        private void Awake()
        {
            PlayerStats = gameObject.GetComponent<Statistics>();
            if(PlayerStats == null)
                PlayerStats = gameObject.AddComponent<Statistics>();

            EquippedEquipment = gameObject.GetComponent<Equipment>();
            if(EquippedEquipment == null)
                EquippedEquipment = gameObject.AddComponent<Equipment>();

            CurrentLevel = gameObject.GetComponent<Levelable>();
            if(CurrentLevel == null)
                CurrentLevel = gameObject.AddComponent<Levelable>();
        }
    }
}