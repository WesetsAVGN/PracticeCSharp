using System;
class Program
{
    static void RectPS(double x1, double y1, double x2, double y2, out double p, out double s)
    {
        double w = Math.Abs(x2 - x1);
        double h = Math.Abs(y2 - y1);

        p = 2 * (w + h);
        s = w * h;
    }

    static void Main()
    {
        for (var i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Прямоугольник {i}:");

            Console.Write("x1: ");
            double x1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("y1: ");
            double y1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("x2: ");
            double x2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("y2: ");
            double y2 = Convert.ToDouble(Console.ReadLine());

            RectPS(x1, y1, x2, y2, out double p, out double s);

            Console.WriteLine($"P = {p:F2}");
            Console.WriteLine($"S = {s:F2}");
        }
    }
}