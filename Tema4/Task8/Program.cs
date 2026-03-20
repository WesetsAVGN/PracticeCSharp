using System;
class Program
{
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static void Swap(ref double a, ref double b)
    {
        double temp = a;
        a = b;
        b = temp;
    }
    static void Main()
    {
        int x = 8;
        int y = 12;

        Swap(ref x, ref y);

        Console.WriteLine($"x = {x}, y = {y}");

        double a = 2.2;
        double b = 8.3;

        Swap(ref a, ref b);

        Console.WriteLine($"a = {a}, b = {b}");
    }
}