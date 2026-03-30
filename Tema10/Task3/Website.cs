using System;

namespace PracticeTasks;

class Website : IWeatherObserver
{
    public void Update(string data)
    {
        Console.WriteLine($"Website: {data}");
    }
}