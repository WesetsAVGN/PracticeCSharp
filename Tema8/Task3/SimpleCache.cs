using System.Collections.Generic;

namespace PracticeTasks;

class SimpleCache<T> : ICache<T>
{
    private List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public IEnumerable<T> GetAll()
    {
        return items;
    }

    public void Clear()
    {
        items.Clear();
    }
}