using System;

class Task7
{
    static void Main()
    {
        Console.WriteLine("Введите координаты A:");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите координаты B:");
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите координаты C:");
        double x3 = Convert.ToDouble(Console.ReadLine());
        double y3 = Convert.ToDouble(Console.ReadLine());

        double a = Distance(x1, y1, x2, y2);
        double b = Distance(x2, y2, x3, y3);
        double c = Distance(x3, y3, x1, y1);

        double perimeter = a + b + c;

        double p = perimeter / 2;

        double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        Console.WriteLine($"P = {perimeter:F3}");
        Console.WriteLine($"S = {area:F3}");
    }
    static double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(
            ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1))
            );
    }
}