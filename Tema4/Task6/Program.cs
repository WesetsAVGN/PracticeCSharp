using System;
class Program
{
    static int MonthDays(int m, int y)
    {
        if ((m < 1) || (m > 12))
        {
            throw new ArgumentOutOfRangeException();
        }

        bool isLeap = (y % 400 == 0) || ((y % 4 == 0) && (y % 100 != 0));

        return m switch
        {
            1 or 3 or 5 or 7 or 8 or 10 or 12 => 31,
            4 or 6 or 9 or 11 => 30,
            2 => isLeap ? 29 : 28,
            _ => 0
        };
    }

    static void Main()
    {
        Console.Write("Введите год Y: ");
        int y = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите M1: ");
        int m1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите M2: ");
        int m2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите M3: ");
        int m3 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"M1: {MonthDays(m1, y)} дней");

        Console.WriteLine($"M2: {MonthDays(m2, y)} дней");

        Console.WriteLine($"M3: {MonthDays(m3, y)} дней");
    }
}