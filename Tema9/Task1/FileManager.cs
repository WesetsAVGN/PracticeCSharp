using System;
using System.IO;

namespace PracticeTasks;

class FileManager
{
    public void CreateFile(string path, string content)
    {
        File.WriteAllText(path, content);
    }

    public string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }

    public void DeleteFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }

        File.Delete(path);
    }

    public void CopyFile(string source, string dest)
    {
        File.Copy(source, dest, true);
    }

    public void MoveFile(string source, string dest)
    {
        File.Move(source, dest, true);
    }

    public void RenameFile(string path, string newName)
    {
        string dir = Path.GetDirectoryName(path);
        string newPath = Path.Combine(dir, newName);

        File.Move(path, newPath, true);
    }

    public void DeleteByPattern(string dir, string pattern)
    {
        string[] files = Directory.GetFiles(dir, pattern);

        foreach (string file in files)
        {
            File.Delete(file);
        }
    }

    public string[] GetFiles(string dir)
    {
        return Directory.GetFiles(dir);
    }
}