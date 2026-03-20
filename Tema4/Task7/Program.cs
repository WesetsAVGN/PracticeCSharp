using System;
class Program
{
    static string GetDesc(int num)
    {
        return num switch
        {
            1 => "один",
            2 => "два",
            3 => "три",
            4 => "четыре",
            _ => "неизвестно"
        };
    }
    static string GetDesc(int num, bool ext)
    {
        return num switch
        {
            5 => "пять",
            6 => "шесть",
            7 => "семь",
            8 => "восемь",
            9 => "девять",
            10 => "десять",
            _ => "неизвестно"
        };
    }

    static void Main()
    {
        Console.Write("Введите число: ");
        int n = Convert.ToInt32(Console.ReadLine());

        string result = (n <= 4) ? GetDesc(n) : GetDesc(n, true);

        Console.WriteLine(result);
    }
}