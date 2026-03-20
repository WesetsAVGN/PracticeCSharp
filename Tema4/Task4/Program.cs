using System;
static class StringExtensions
{
    public static string RemoveSpaces(this string val)
    {
        return val.Replace(" ", "");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string txt = Console.ReadLine();

        string result = txt.RemoveSpaces();

        Console.WriteLine(result);
    }
}