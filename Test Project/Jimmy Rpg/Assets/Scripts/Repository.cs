using Assets.Scripts.Util;
using System.Collections.Generic;
using Assets.Scripts.Story;
using System;

namespace Assets.Scripts
{
    public class Repository : IRepository
    {
        private IList<StoryModel> _stories;
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
        public IList<StoryModel> GetStories()
        {
            try
            {
                var json = JsonHelper.GetJsonFromFile(GameSettings.StoryJsonFilePath);
                _stories = JsonHelper.JsonToModel<IList<StoryModel>>(json);
                return _stories;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured Getting stories", ex);
            }
        }
    }
}
