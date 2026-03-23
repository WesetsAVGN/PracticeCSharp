class Program
{
    static void Main()
    {
        BatMon monitor = new();

        PwrSaver saver = new();
        UserNotif notifier = new();

        PwrManager manager = new(monitor, saver, notifier);

        Console.Write("Уровень заряда батареи (%): ");
        string prcnt = Console.ReadLine();
        int bat = int.Parse(prcnt);

        monitor.CheckBattery(bat);
    }
}