using System;

namespace PracticeTasks;

class Bicycle : IVehicle
{
    public void Move()
    {
        Console.WriteLine("Велосипед едет.");
    }
}