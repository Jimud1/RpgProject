using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Entities;
using Assets.Scripts.GameLogic.Models;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Services.Monster
{
    public class MonsterService : IMonsterService
    {
        IRepository _respository;
        public MonsterService(IRepository respository)
        {
            _respository = respository;
        }
        public IEnumerable<MonsterGameModel> Get()
        {
            return _respository.GameContext.Monsters.Select(EntityToModel);
        }

        public MonsterGameModel Get(int id)
        {
            return Get().Where(x => x.MonsterId == id).FirstOrDefault();
        }


        private MonsterGameModel EntityToModel(MonsterEntity entity)
        {
            var obj = new GameObject();
            var model = obj.AddComponent<MonsterGameModel>();
            model.Enemy = AssetDatabase.LoadAssetAtPath<GameObject>(entity.PrefabPath);
            model.Statistics = entity.Statistics;
            model.MonsterId = entity.MonsterId;
            model.MonsterDescription = entity.MonsterDescription;
            model.MonsterName = entity.MonsterName;
            return model;
        }

        #region Not implemented

        public MonsterGameModel Add(MonsterGameModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public void Update(int id, MonsterGameModel item)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
