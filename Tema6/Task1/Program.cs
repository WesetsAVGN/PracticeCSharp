using System;
class Program
{
    static void Main()
    {
        UpCaseConv upper = new();
        LowCaseConv lower = new();

        TxtProcessor proc;

        proc = upper.Convert;
        Console.WriteLine(proc("Hello World!"));

        proc = lower.Convert;
        Console.WriteLine(proc("Hello World!"));
    }
}