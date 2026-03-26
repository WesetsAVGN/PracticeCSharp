using System;
using System.IO;

namespace PracticeTasks;

class FileWatcher
{
    private FileSystemWatcher watcher;

    public FileWatcher(string path)
    {
        watcher = new FileSystemWatcher(path);

        watcher.Renamed += OnRenamed;

        watcher.EnableRaisingEvents = true;
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        string message = $"Файл {e.OldName} " + $"переименован в {e.Name}";

        Console.WriteLine(message);

        File.AppendAllText("log.txt", message + Environment.NewLine);
    }
}