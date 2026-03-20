using System;
abstract class Employee
{
    public string Name { get; set; }
    public abstract double CalcSal();
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Имя: {Name}");
    }
}

class Manager : Employee
{
    public double FixedSal { get; set; }
    public override double CalcSal()
    {
        return FixedSal;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Менеджер: {Name}, " + $"ЗП: {CalcSal():F2}");
    }
}

class Developer : Employee
{
    public int Hours { get; set; }
    public double Rate { get; set; }
    public override double CalcSal()
    {
        return Hours * Rate;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Разработчик: {Name}, " + $"ЗП: {CalcSal():F2}");
    }
}

class Program
{
    static void Main()
    {
        Employee manager = new Manager
        {
            Name = "Ivan",
            FixedSal = 5000
        };

        Employee manager1 = new Manager
        {
            Name = "Ilya",
            FixedSal = 7000
        };

        Employee dev = new Developer
        {
            Name = "Anna",
            Hours = 160,
            Rate = 25
        };
        Employee dev1 = new Developer
        {
            Name = "Eugene",
            Hours = 240,
            Rate = 35
        };

        manager.DisplayInfo();
        manager1.DisplayInfo();
        dev.DisplayInfo();
        dev1.DisplayInfo();
    }
}