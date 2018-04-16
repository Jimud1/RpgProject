using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Assets.StoryController
{
    public class StoryService : IStoryService
    {
        IStoryRepository _storyRepo;

        public StoryService()
        {
            _storyRepo = new StoryRepository();
        }

        public IEnumerable<StoryModel> Get()
        {
            return _storyRepo.Stories;
        }

        public StoryModel Get(int id)
        {
            return Get().Where(x => x.StoryId == id).FirstOrDefault();
        }

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
    }
}
