using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IService<T> 
{
    IEnumerable<T> Get();
    T Get(int id);
    T Add(T item);
    void Update(int id, T item);
    void Delete(int id);
}
