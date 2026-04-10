using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace TaskManager;

public partial class MainWindow : Window
{
    private Point startPoint;
    private string username;

    public MainWindow(string username)
    {
        InitializeComponent();
        this.username = username;
        DataContext = new TaskManagerViewModel(username);

        var vm = new TaskManagerViewModel(username);
        DataContext = vm;

        Loaded += async (_, __) => await vm.LoadTasksAsync();
    }

    private void MainGrid_Loaded(object sender, RoutedEventArgs e)
    {
        var sb = (Storyboard)Resources["FadeInAnimation"];
        sb.Begin(this);
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
            new MainWindow(login.Username).Show();
            Close();
        }
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    // ---------- DRAG ----------

    private void Task_MouseDown(object sender, MouseButtonEventArgs e)
    {
        startPoint = e.GetPosition(null);
    }

    private void Task_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed)
            return;

        Point pos = e.GetPosition(null);

        if (Math.Abs(pos.X - startPoint.X) < 5 &&
            Math.Abs(pos.Y - startPoint.Y) < 5)
            return;

        if (TaskList.SelectedItem == null)
            return;

        DragDrop.DoDragDrop(TaskList, TaskList.SelectedItem, DragDropEffects.Move);
    }

    private async void Task_Drop(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(typeof(TaskItem)))
            return;

        var droppedData = e.Data.GetData(typeof(TaskItem)) as TaskItem;
        var target = ((FrameworkElement)e.OriginalSource).DataContext as TaskItem;

        if (droppedData == null || target == null || droppedData == target)
            return;

        var vm = DataContext as TaskManagerViewModel;

        int oldIndex = vm.Tasks.IndexOf(droppedData);
        int newIndex = vm.Tasks.IndexOf(target);

        if (oldIndex < 0 || newIndex < 0)
            return;

        vm.Tasks.Move(oldIndex, newIndex);
        await vm.UpdateOrderAsync();
    }
}