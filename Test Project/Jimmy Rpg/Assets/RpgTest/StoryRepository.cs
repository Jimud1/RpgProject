using System.Collections.Generic;

namespace Assets.RpgTest
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

        public IList<StoryModel> GetStories(string filePath = @"E:\Development\Test Project\Jimmy Rpg\Assets\RpgTest\Story.json")
        {
            //Why isn't dis workin'?
            var json = JsonHelper.GetJsonFromFile(filePath);
            var model = JsonHelper.JsonToModel<StoryModel>(json);
            _stories = new List<StoryModel>
            {
                model
            };
            return _stories;
        }
    }
}
