using System;

namespace PracticeTasks;

class Program
{
    static void Main()
    {
        TaxCalculator calc = new();

        calc.SetStrategy(new USTax());
        Console.WriteLine(calc.Calculate(100));

        calc.SetStrategy(new EUTax());
        Console.WriteLine(calc.Calculate(100));
    }
}