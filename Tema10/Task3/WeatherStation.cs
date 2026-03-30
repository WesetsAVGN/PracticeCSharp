using System.Collections.Generic;

namespace PracticeTasks;

class WeatherStation
{
    private List<IWeatherObserver> observers = [];

    public void Subscribe(IWeatherObserver observer)
    {
        observers.Add(observer);
    }

    public void Notify(string data)
    {
        foreach (IWeatherObserver observer in observers)
        {
            observer.Update(data);
        }
    }
}