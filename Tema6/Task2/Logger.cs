using System;
using System.IO;
class Logger
{
    public void ConsoleLog(string message)
    {
        Console.WriteLine($"Console: {message}");
    }

    public void FileLog(string message)
    {
        File.AppendAllText("log.txt", message + Environment.NewLine);
    }
}