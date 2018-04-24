using Assets.Scripts.Settings;
using Assets.Scripts.Util;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Data.Entities
{
    public class JsonGameContext
    {
        #region Constructor
        public JsonGameContext()
        {
            //Initialise values 
            GetWeapons();
            GetStories();
        }
        #endregion

        #region Stories
        /// <summary>
        /// Stories
        /// </summary>
        public IEnumerable<StoryModel> Stories
        {
            get
            {
                return _stories ?? (_stories = GetStories());
            }
        }
        private IEnumerable<StoryModel> _stories;
        #endregion

        #region Weapons
        /// <summary>
        /// Weapons
        /// </summary>
        public IEnumerable<WeaponModel> Weapons
        {
            get
            {
                return _weapons ?? (_weapons = GetWeapons());
            }
        }
        private IEnumerable<WeaponModel> _weapons;
        #endregion

        #region Quests
        public IEnumerable<QuestModel> Quests
        {
            get
            {
                return _quests ?? (_quests = GetQuests());
            }
        }
        private IEnumerable<QuestModel> _quests;
        #endregion

        #region Armour
        public IEnumerable<ArmourModel> Armours
        {
            get
            {
                return _armours ?? (_armours = GetArmours());
            }
        }

        public IEnumerable<ArmourModel> _armours;
        #endregion

        #region Monsters
        private IEnumerable<MonsterEntity> _monsters;
        public IEnumerable<MonsterEntity> Monsters
        {
            get
            {
                return _monsters ?? (_monsters = GetMonsters());
            }
        }
        #endregion

        #region Get Monsters
        /// <summary>
        /// Get armour from Json
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MonsterEntity> GetMonsters()
        {
            try
            {
                var json = JsonHelper.GetJsonFromFile(GameSettings.MonstersJsonPath);
                _monsters = JsonHelper.JsonToModel<IEnumerable<MonsterEntity>>(json);
                return _monsters;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured getting armours from json", ex);
            }
        }
        #endregion

        #region Get Armours
        /// <summary>
        /// Get armour from Json
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ArmourModel> GetArmours()
        {
            try
            {
                var json = JsonHelper.GetJsonFromFile(GameSettings.ArmoursJsonPath);
                _armours = JsonHelper.JsonToModel<IEnumerable<ArmourModel>>(json);
                return _armours;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured getting armours from json", ex);
            }
        }
        #endregion

        #region Get Quests from json 
        private IEnumerable<QuestModel> GetQuests()
        {
            try
            {
                var json = JsonHelper.GetJsonFromFile(GameSettings.QuestsJsonPath);
                _quests = JsonHelper.JsonToModel<IEnumerable<QuestModel>>(json);
                return _quests;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured Getting quests", ex);
            }
        }
        #endregion

        #region Get Weapons from json
        /// <summary>
        /// Get weapons will fill in weapons if it's null
        /// </summary>
        /// <returns></returns>
        private IEnumerable<WeaponModel> GetWeapons()
        {
            try
            {
                var json = JsonHelper.GetJsonFromFile(GameSettings.WeaponsJsonPath);
                _weapons = JsonHelper.JsonToModel<IEnumerable<WeaponModel>>(json);
                return _weapons;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured Getting stories", ex);
            }
        }
        #endregion

        #region Get Stories from json
        /// <summary>
        /// Get Stories will fill in our stories if null
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private IEnumerable<StoryModel> GetStories()
        {
            try
            {
                var json = JsonHelper.GetJsonFromFile(GameSettings.StoryJsonFilePath);
                _stories = JsonHelper.JsonToModel<IEnumerable<StoryModel>>(json);
                return _stories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured Getting stories", ex);
            }
        }
        #endregion

    }
}