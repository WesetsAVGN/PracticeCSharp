namespace PracticeTasks;

class Program
{
    static void Main()
    {
        SimpleCache<string> cache = new();

        cache.Add("A");
        cache.Add("B");

        CacheManager<string> manager = new(cache);

        manager.PrintCache();
        System.Console.WriteLine(manager.Count());
    }
}