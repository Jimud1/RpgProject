using Assets.Scripts.Data.Entities;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class Equipment
    {
        public IWeapon Weapon { get; set;}
        public IArmour Armour { get; set; }
        public IArmour Gloves { get; set; }
        public IArmour Pants { get; set; }
        public IArmour Boots { get; set; }
        public IArmour Helmet { get; set; }
    }
}
