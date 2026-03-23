using System;
class Program
{
    static void Main()
    {
        Logger logger = new();
        LogServ service = new();

        service.LogMsg("Test message", logger.ConsoleLog);

        service.LogMsg("File message", logger.FileLog);
    }
}