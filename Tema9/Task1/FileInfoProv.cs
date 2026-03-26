using System.IO;

namespace PracticeTasks;

class FileInfoProvider
{
    public FileInfo GetInfo(string path)
    {
        return new FileInfo(path);
    }
}