using System;
class Employee
{
    public string Name { get; set; }
}

interface IManager
{
    void Manage();
}

interface IWorker
{
    void Work();
}

class Director : Employee, IManager
{
    public void Manage()
    {
        Console.WriteLine($"{Name} управляет");
    }
}

class Engineer : Employee, IWorker
{
    public void Work()
    {
        Console.WriteLine($"{Name} работает");
    }
}

class Task3_Interfaces
{
    static void Main()
    {
        Employee[] staff =
        [
            new Director { Name = "Inna" },
            new Engineer { Name = "Alexander" }
        ];

        Console.WriteLine("Менеджеры:");

        foreach (Employee emp in staff)
        {
            if (emp is IManager manager)
            {
                manager.Manage();
            }
        }
    }
}