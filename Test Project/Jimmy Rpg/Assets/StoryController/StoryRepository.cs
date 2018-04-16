using System.Collections.Generic;

namespace Assets.StoryController
{
    public class StoryRepository : IStoryRepository
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
        public IList<StoryModel> GetStories(string filePath = @"E:\Development\RpgProject\RpgProject\Test Project\Jimmy Rpg\Assets\StoryController\Story - Copy.json")
        {
            var json = JsonHelper.GetJsonFromFile(filePath);
            _stories = JsonHelper.JsonToModel<IList<StoryModel>>(json);
            return _stories;
        }
    }
}
