using System.Collections.Generic;

namespace PracticeTasks;

interface ICache<T>
{
    void Add(T item);
    IEnumerable<T> GetAll();
    void Clear();
}