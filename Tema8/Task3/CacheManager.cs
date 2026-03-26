using System;

namespace PracticeTasks;

class CacheManager<T>
{
    private ICache<T> cache;

    public CacheManager(ICache<T> cache)
    {
        this.cache = cache;
    }

    public void PrintCache()
    {
        foreach (T item in cache.GetAll())
        {
            Console.WriteLine(item);
        }
    }

    public int Count()
    {
        int count = 0;

        foreach (T _ in cache.GetAll())
        {
            count++;
        }

        return count;
    }
}