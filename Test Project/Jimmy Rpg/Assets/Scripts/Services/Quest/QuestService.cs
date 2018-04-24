using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Entities;

namespace Assets.Scripts.Services
{
    public class QuestService : IQuestService
    {
        IRepository _repository;
        public QuestService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<QuestModel> Get()
        {
            return _repository.GameContext.Quests;
        }

        public QuestModel Get(int id)
        {
            return Get().Where(x => x.QuestId == id).FirstOrDefault();
        }
        #region Not implemented
        public QuestModel Add(QuestModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, QuestModel item)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
