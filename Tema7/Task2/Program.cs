using System;
class Program
{
    static void Main()
    {
        NumProc processor = new();

        try
        {
            processor.Process("abc");
        }
        catch (InvalidNumberException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");

            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner: {ex.InnerException.Message}");
            }
        }
    }
}