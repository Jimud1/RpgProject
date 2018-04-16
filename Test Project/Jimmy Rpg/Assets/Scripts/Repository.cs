using Assets.Scripts.Util;
using System.Collections.Generic;
using Assets.Scripts.Story;
using UnityEngine;

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
        public IList<StoryModel> GetStories(string filePath = @"E:\Development\RpgProject\RpgProject\Test Project\Jimmy Rpg\Assets\Scripts\Story\Json\Story - Copy.json")
        {
            var json = JsonHelper.GetJsonFromFile(filePath);
            _stories = JsonHelper.JsonToModel<IList<StoryModel>>(json);
            return _stories;
        }
    }
}
