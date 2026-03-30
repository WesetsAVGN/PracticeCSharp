using System.Windows.Input;

namespace PracticeTasks;

class PauseCommand : ICommand
{
    private MusicPlayer player;

    public PauseCommand(MusicPlayer player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Pause();
    }
}