using Assets.Scripts.GameLogic;
using Assets.Scripts.StoryFlowController;
using UnityEngine;

namespace Assets.Scripts.PlayerControls
{
    public class Player : MonoBehaviour, IPlayerControllable, ILevelable, IDamageable, IAttackable
    {
        
        #region Stats
        Statistics PlayerStats;

        public float Experience
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int Level { get; set; }

        public float Health
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }

        #endregion

        #region Equipment
        Equipment EquippedEquipment;
        float DefenseRate
        {
            get
            {
                return EquippedEquipment.Armour.Defense + EquippedEquipment.Gloves.Defense + 
                    EquippedEquipment.Pants.Defense + EquippedEquipment.Boots.Defense + EquippedEquipment.Helmet.Defense;
            }
        }

        public float Attack()
        {
            var attack = PlayerStats.Strength;

            if (EquippedEquipment.Weapon != null)
                attack += EquippedEquipment.Weapon.Attack;

            return attack;
        }

        public void Damage(float damage)
        {
            var dmg = DefenseRate - damage;
            Health -= dmg;
        }
        #endregion

        GameObject SceneManager;
        StoryFlowManager _flowManager;

        private void Start()
        {
            SceneManager = GameObject.FindGameObjectWithTag("Manager");
            _flowManager = SceneManager.GetComponent<StoryFlowManager>();
        }

        #region Move, Attack, Damage and Update
        public void Move()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

            transform.Translate(x, 0, 0);
            transform.Translate(0, 0, y);
        }
        
        private void Update()
        {
            if(!_flowManager.Conversing)
                Move();
        }
        #endregion
    }
}