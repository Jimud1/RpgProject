using System;
using UnityEngine;
using UnityEngine.UI;
using GoH = Assets.Scripts.Util.GameObjectHelper;

namespace Assets.Scripts.GameLogic
{
    public class GameBars : MonoBehaviour, IDamageable
    {
        [SerializeField]
        Image FullHp;
        [SerializeField]
        Image EmptyHp;

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

        void UpdateHpImageText()
        {
            var text = FullHp.GetComponent<Text>();
            GoH.UpdateText(text, CurrentHp.ToString() + " / " + MaxHp.ToString());
        }

        public void Damage(float damage)
        {
            CurrentHp -= damage;
            var displayHealth = (CurrentHp / MaxHp);

            if (displayHealth <= 0)
                displayHealth = 0;
            if (displayHealth >= Stats.MaxHp)
                displayHealth = Stats.MaxHp;

            //UpdateHpImageText();
            FullHp.transform.localScale = new Vector3(displayHealth, 1, 1);
        }
    }
}
