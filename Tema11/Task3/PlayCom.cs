using System.Windows.Input;

namespace PracticeTasks;

class PlayCommand : ICommand
{
    private MusicPlayer player;

    public PlayCommand(MusicPlayer player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Play();
    }
}