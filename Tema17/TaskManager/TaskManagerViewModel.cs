using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace TaskManager;

public class TaskManagerViewModel : TaskModel
{
    private readonly TaskService service = new();
    private readonly string username;

    public ObservableCollection<TaskItem> Tasks { get; set; } = new();

    private TaskItem selectedTask;
    public TaskItem SelectedTask
    {
        get => selectedTask;
        set
        {
            selectedTask = value;
            OnPropertyChanged();

            CommandManager.InvalidateRequerySuggested();
        }
    }

    private bool isLoading;
    public bool IsLoading
    {
        get => isLoading;
        set { isLoading = value; OnPropertyChanged(); }
    }

    public ICommand AddTaskCommand { get; }
    public ICommand EditTaskCommand { get; }
    public ICommand DeleteTaskCommand { get; }

    public TaskManagerViewModel(string username)
    {
        this.username = username;

        AddTaskCommand = new RelayCommand(AddTask);
        EditTaskCommand = new RelayCommand(EditTask, () => SelectedTask != null);
        DeleteTaskCommand = new RelayCommand(DeleteTask, () => SelectedTask != null);

        LoadTasksAsync();
    }

    private async void LoadTasksAsync()
    {
        IsLoading = true;

        var loaded = await service.LoadTasksAsync(username);
        Tasks = new ObservableCollection<TaskItem>(loaded);

        OnPropertyChanged(nameof(Tasks));
        IsLoading = false;
    }

    private void Save()
    {
        service.SaveTasks(username, Tasks.ToList());
    }

    private void AddTask()
    {
        var window = new TaskWindow();

        if (window.ShowDialog() == true)
        {
            Tasks.Add(window.Task);
            Save();
        }
    }

    private void EditTask()
    {
        if (SelectedTask == null) return;

        var copy = new TaskItem
        {
            Title = SelectedTask.Title,
            Status = SelectedTask.Status,
            Priority = SelectedTask.Priority
        };

        var window = new TaskWindow(copy);

        if (window.ShowDialog() == true)
        {
            SelectedTask.Title = window.Task.Title;
            SelectedTask.Status = window.Task.Status;
            SelectedTask.Priority = window.Task.Priority;

            Save();
        }
    }

    private void DeleteTask()
    {
        if (SelectedTask == null) return;

        if (MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            Tasks.Remove(SelectedTask);
            Save();
        }
    }
}