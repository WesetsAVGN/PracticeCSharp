using System.Windows.Input;

namespace PracticeTasks;

class StopCommand : ICommand
{
    private MusicPlayer player;

    public StopCommand(MusicPlayer player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Stop();
    }
}