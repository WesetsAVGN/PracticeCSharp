using System.Windows;

namespace TaskManager;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var login = new LoginWindow();

        if (login.ShowDialog() == true)
        {
            var main = new MainWindow(login.Username);
            main.Show();
        }
        else
        {
            Shutdown();
        }
    }
}