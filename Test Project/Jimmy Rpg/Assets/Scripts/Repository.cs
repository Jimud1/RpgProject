using Assets.Scripts.Util;
using System.Collections.Generic;
using Assets.Scripts.Entities;
using System;

namespace Assets.Scripts
{
    public class Repository : IRepository
    {
        private IEnumerable<StoryModel> _stories;
        public IEnumerable<StoryModel> Stories
        {
            get
            {
                return _stories ?? (_stories = GetStories());
            }
        }

        /// <summary>
        /// Get Stories will fill in our stories if we don't currently have any
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IEnumerable<StoryModel> GetStories()
        {
            try
            {
                var json = JsonHelper.GetJsonFromFile(GameSettings.StoryJsonFilePath);
                _stories = JsonHelper.JsonToModel<IEnumerable<StoryModel>>(json);
                return _stories;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured Getting stories", ex);
            }
        }
    }
}
