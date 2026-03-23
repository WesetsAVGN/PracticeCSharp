class BatMon
{
    public event EventHandler BatteryLow;

    public void CheckBattery(int level)
    {
        if (level < 20)
        {
            BatteryLow?.Invoke(this, EventArgs.Empty);
        }
    }
}