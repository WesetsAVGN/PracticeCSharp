using System;
class Program
{
    static void Main()
    {
        Calculator calc = new();

        try
        {
            int result = calc.Divide(10, 0);
            Console.WriteLine(result);
        }
        catch (DivisionByZeroException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}