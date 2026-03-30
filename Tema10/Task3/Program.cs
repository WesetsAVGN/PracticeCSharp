namespace PracticeTasks;

class Program
{
    static void Main()
    {
        WeatherStation station = new();

        MobileApp mobile = new();
        Website site = new();

        station.Subscribe(mobile);
        station.Subscribe(site);

        station.Notify("Температура: 20°C");
    }
}