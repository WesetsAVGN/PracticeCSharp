using System.Windows;

namespace TaskManager;

public partial class MainWindow : Window
{
    private string username;

    public MainWindow(string username)
    {
        InitializeComponent();
        this.username = username;
        DataContext = new TaskManagerViewModel(username);
    }

    private void OpenChat_Click(object sender, RoutedEventArgs e)
    {
        new ChatWindow().Show();
    }

    private void Logout_Click(object sender, RoutedEventArgs e)
    {
        var login = new LoginWindow();

        if (login.ShowDialog() == true)
        {
            var main = new MainWindow(login.Username);
            main.Show();
            Close();
        }
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

}