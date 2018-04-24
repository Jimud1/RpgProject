using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Entities;

namespace Assets.Scripts.Services
{
    public class WeaponService : IWeaponService
    {
        IRepository _repository;
        public WeaponService(IRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<WeaponModel> Get()
        {
           return _repository.GameContext.Weapons;
        }

        public WeaponModel Get(int id)
        {
            return Get().Where(x => x.ItemId == id).FirstOrDefault();
        }

        #region Unimplemented
        public void Update(int id, WeaponModel item)
        {
            throw new System.NotImplementedException();
        }

        public WeaponModel Add(WeaponModel item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
