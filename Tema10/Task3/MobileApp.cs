using System;

namespace PracticeTasks;

class MobileApp : IWeatherObserver
{
    public void Update(string data)
    {
        Console.WriteLine($"Mobile: {data}");
    }
}