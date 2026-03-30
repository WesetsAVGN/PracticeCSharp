using System;

namespace PracticeTasks;

class Program
{
    static void Main()
    {
        IText text = new PlainText("Hello World!");

        text = new BoldDecorator(text);
        text = new ItalicDecorator(text);

        Console.WriteLine(text.GetContent());
    }
}