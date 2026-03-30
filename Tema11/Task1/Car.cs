using System;

namespace PracticeTasks;

class Car : IVehicle
{
    public void Move()
    {
        Console.WriteLine("Машина едет.");
    }
}