namespace PracticeTasks;

class Program
{
    static void Main()
    {
        MusicPlayer player = new();
        PlayerRemote remote = new();

        remote.SetCommand(new PlayCommand(player));
        remote.PressButton();

        remote.SetCommand(new PauseCommand(player));
        remote.PressButton();
    }
}