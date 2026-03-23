class LogServ
{
    public void LogMsg(string message, LogHandler handler)
    {
        handler(message);
    }
}