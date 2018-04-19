using System.Collections.Generic;
using System.Linq;
using System;

namespace Assets.Scripts.Story
{
    public class StoryService : IStoryService
    {
        IRepository _repository;

        public StoryService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<StoryModel> Get()
        {
            return _repository.Stories;
        }

        public StoryModel Get(int id)
        {
            return Get().Where(x => x.StoryId == id).FirstOrDefault();
        }

        #region Not implemented
        public StoryModel Add(StoryModel item)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, StoryModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
