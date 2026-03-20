using System;

class Task
{
    public int a;
    public int b;

    public Task(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public double GetQuot()
    {
        return (double)a / b;
    }
    public double GetCbRt()
    {
        return Math.Cbrt(a + b);
    }
}

class Program
{
    static void Main()
    {
        Task obj = new(10, 2);

        Console.WriteLine($"a = {obj.a}");
        Console.WriteLine($"b = {obj.b}");

        Console.WriteLine($"Частное: {obj.GetQuot():F2}");

        Console.WriteLine($"Кубический корень: {obj.GetCbRt():F4}");
    }
}