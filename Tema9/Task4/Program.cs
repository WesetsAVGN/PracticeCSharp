using System;

namespace PracticeTasks;

class Program
{
    static void Main()
    {
        FileWatcher watcher = new(".");

        Console.WriteLine("Наблюдение запущено...");
        Console.ReadLine();
    }
}