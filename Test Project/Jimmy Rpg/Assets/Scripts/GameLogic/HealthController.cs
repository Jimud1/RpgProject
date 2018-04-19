using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameLogic
{
    public class HealthController : MonoBehaviour, IDamageable
    {
        [SerializeField]
        Image FullHp;

        float CurrentHp
        {
            get
            {
                return Stats.CurrentHp;
            }
            set
            {
                Stats.CurrentHp = value;
            }
        }
        float MaxHp
        {
            get
            {
                return Stats.MaxHp;
            }
        }
        Statistics Stats
        {
            get
            {
                return gameObject.GetComponent<Statistics>();
            }
        }

        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                Damage(10);
            }
        }

        public void Heal(float health)
        {
            CurrentHp += health;

            var displayHealth = (CurrentHp / MaxHp);

            if (displayHealth <= 0)
                displayHealth = 0;
            if (displayHealth >= Stats.MaxHp)
                displayHealth = Stats.MaxHp;

            DisplayHealth(displayHealth);
        }

        private void DisplayHealth(float display)
        {
            FullHp.fillAmount = display;
        }

        public void Damage(float damage)
        {
            CurrentHp -= damage;
            var displayHealth = (CurrentHp / MaxHp);

            MaxMinCheck(displayHealth);

            DisplayHealth(displayHealth);
        }

        private void MaxMinCheck(float value)
        {
            if (value <= 0)
                value = 0;
            if (value >= Stats.MaxHp)
                value = Stats.MaxHp;
        }
    }
}
