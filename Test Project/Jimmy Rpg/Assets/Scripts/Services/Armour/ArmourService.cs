using Assets.Scripts.Data;
using Assets.Scripts.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Services
{
    public class ArmourService : IArmourService
    {
        IRepository _repository;
        public ArmourService(IRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<ArmourModel> Get()
        {
            return _repository.GameContext.Armours;
        }

        public ArmourModel Get(int id)
        {
            return Get().Where(x => x.ItemId == id).FirstOrDefault();
        }
        #region Not implemented
        public ArmourModel Add(ArmourModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ArmourModel item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
