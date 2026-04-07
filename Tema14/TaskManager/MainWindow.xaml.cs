using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace TaskManager;

public partial class MainWindow : Window
{
    public ObservableCollection<TaskItem> Tasks { get; set; } = new();
    public ObservableCollection<TaskItem> FilteredTasks { get; set; } = new();

    public TaskItem NewTask { get; set; } = new()
    {
        Status = "В работе",
        Priority = "Средний"
    };

    private TaskItem selectedTask;
    public TaskItem SelectedTask
    {
        get => selectedTask;
        set
        {
            selectedTask = value;
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public ICommand AddTaskCommand { get; }
    public ICommand EditTaskCommand { get; }
    public ICommand DeleteTaskCommand { get; }

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        AddTaskCommand = new RelayCommand(AddTask);
        EditTaskCommand = new RelayCommand(EditTask, () => SelectedTask != null);
        DeleteTaskCommand = new RelayCommand(DeleteTask, () => SelectedTask != null);

        InputBindings.Add(new KeyBinding(AddTaskCommand, new KeyGesture(Key.N, ModifierKeys.Control)));
        InputBindings.Add(new KeyBinding(EditTaskCommand, new KeyGesture(Key.E, ModifierKeys.Control)));
        InputBindings.Add(new KeyBinding(DeleteTaskCommand, new KeyGesture(Key.D, ModifierKeys.Control)));

        StatusFilter.SelectedIndex = 0;

        UpdateFilter();
    }

    private void AddTask()
    {
        TaskWindow window = new();

        if (window.ShowDialog() == true)
        {
            Tasks.Add(window.Task);
            UpdateFilter();
        }
    }

    private void EditTask()
    {
        if (SelectedTask == null) return;

        TaskWindow window = new(SelectedTask);

        if (window.ShowDialog() == true)
        {
            int index = Tasks.IndexOf(SelectedTask);
            Tasks[index] = window.Task;
            UpdateFilter();
        }
    }

    private void DeleteTask()
    {
        if (SelectedTask == null) return;

        var result = MessageBox.Show("Удалить задачу?", "Подтверждение", MessageBoxButton.YesNo);

        if (result == MessageBoxResult.Yes)
        {
            Tasks.Remove(SelectedTask);
            UpdateFilter();
        }
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NewTask.Title)) return;

        Tasks.Add(new TaskItem
        {
            Title = NewTask.Title,
            Status = NewTask.Status,
            Priority = NewTask.Priority
        });

        NewTask = new TaskItem { Status = "В работе", Priority = "Средний" };
        DataContext = null;
        DataContext = this;

        UpdateFilter();
    }

    private void StatusFilter_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        UpdateFilter();
    }

    private void UpdateFilter()
    {
        string filter = (StatusFilter.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

        FilteredTasks.Clear();

        var data = filter == "Все"
            ? Tasks
            : Tasks.Where(t => t.Status == filter);

        foreach (var item in data)
        {
            FilteredTasks.Add(item);
        }
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void About_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(
           "Task Manager\nПриложение для управления задачами.\n\n\n\n\nМосевич Артур Андреевич",
            "О программе");
    }
}