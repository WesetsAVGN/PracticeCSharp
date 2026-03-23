class PwrManager
{
    public PwrManager(BatMon monitor, PwrSaver saver, UserNotif notifier)
    {
        monitor.BatteryLow += saver.Enable;
        monitor.BatteryLow += notifier.Notify;
    }
}