using System;
using System.IO;

namespace PracticeTasks;

class Program
{
    static void Main()
    {
        FileManager manager = new();
        FileInfoProvider info = new();

        string path = "test.txt";

        manager.CreateFile(path, "Hello");
        Console.WriteLine(manager.ReadFile(path));

        FileInfo fileInfo = info.GetInfo(path);
        Console.WriteLine(fileInfo.Length);

        manager.CopyFile(path, "copy.txt");
        manager.MoveFile("copy.txt", "moved.txt");

        manager.RenameFile("moved.txt", "mosevich.aa");

        try
        {
            manager.DeleteFile("no_file.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        string[] files = manager.GetFiles(".");

        foreach (string f in files)
        {
            Console.WriteLine(f);
        }
    }
}