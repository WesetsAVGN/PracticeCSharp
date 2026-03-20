using System;
class Program
{
    static int NOD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return Math.Abs(a);
    }

    static void Main()
    {
        Console.Write("Введите a: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите b: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int nod = NOD(a, b);

        Console.WriteLine($"НОД: {nod}");
    }
}