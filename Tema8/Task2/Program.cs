using System;

namespace PracticeTasks;

class Program
{
    static void Main()
    {
        StackHistory<string> history = new();

        history.Add("Action1");
        history.Add("Action2");

        Console.WriteLine(history.Undo());
    }
}