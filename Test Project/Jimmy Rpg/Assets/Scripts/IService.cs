using Assets.Scripts.Entities;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public interface IService<T> where T: IEntity
    {
        IEnumerable<T> Get();
        T Get(int id);
        T Add(T item);
        void Update(int id, T item);
        void Delete(int id);
    }
}