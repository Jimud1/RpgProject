
using Assets.Scripts.Data;
using Assets.Scripts.GameLogic;
using Assets.Scripts.GameLogic.Models;
using Assets.Scripts.Services.Monster;
using UnityEngine;

namespace Assets.Scripts.DataControllers
{
    public class MonsterController : MonoBehaviour
    {
        IMonsterService _monsterService;

        public void Get(int id)
        {
            _monsterService = new MonsterService(new Repository());
            var monster = _monsterService.Get(id);
            var test = Instantiate(monster.Enemy);

            var stats = test.AddComponent<GameStats>();
            stats.Strength = monster.Statistics.Strength;
            stats.MaxHp = monster.Statistics.MaxHp;
            stats.CurrentHp = stats.MaxHp;
        }

        public void Update()
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                Get(1);
            }
        }
    }
}
