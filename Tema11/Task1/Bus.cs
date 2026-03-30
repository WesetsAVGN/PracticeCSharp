using System;

namespace PracticeTasks;

class Bus : IVehicle
{
    public void Move()
    {
        Console.WriteLine("Автобус едет.");
    }
}