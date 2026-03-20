using System;
class Program
{
    static int GCD(int a, int b)
    {
        if (b == 0)
        {
            return Math.Abs(a);
        }

        return GCD(b, a % b);
    }

    static void Main()
    {
        Console.Write("Введите a: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите b: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int result = GCD(a, b);

        Console.WriteLine($"НОД: {result}");
    }
}