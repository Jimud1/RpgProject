using UnityEngine;
namespace Assets.Scripts.GameLogic
{
    public class Statistics : MonoBehaviour,  IStatistical
    {
        public float Strength
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

        public float Dexterity
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
        public float Accuracy
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
        public float Constitution
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
        public float Intelligence
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
        public float Wisdom
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

        private float _maxHp = 100;
        public float MaxHp
        {
            get
            {
                return _maxHp;
            }

            set
            {
                _maxHp = value;
            }
        }
        private float? _currentHp;
        public float CurrentHp
        {
            get
            {
                if (_currentHp == null)
                    _currentHp = MaxHp;

                return (float) _currentHp;
            }
            set
            {
                _currentHp = value;
            }
        }
    }
}
