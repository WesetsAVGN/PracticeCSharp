using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TaskManager;

public class TaskManagerViewModel : TaskModel
{
    private readonly TaskService service = new();

    public ObservableCollection<TaskItem> Tasks { get; set; } = new();

    private TaskItem selectedTask;
    public TaskItem SelectedTask
    {
        get => selectedTask;
        set { selectedTask = value; OnPropertyChanged(); }
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

    public TaskManagerViewModel()
    {
        AddTaskCommand = new RelayCommand(AddTask);
        EditTaskCommand = new RelayCommand(EditTask, () => SelectedTask != null);
        DeleteTaskCommand = new RelayCommand(DeleteTask, () => SelectedTask != null);

        LoadTasksAsync();
    }

    private async void LoadTasksAsync()
    {
        IsLoading = true;
        var loadedTasks = await service.LoadTasksAsync();
        Tasks = new ObservableCollection<TaskItem>(loadedTasks);
        OnPropertyChanged(nameof(Tasks));
        IsLoading = false;
    }

    private void AddTask()
    {
        var window = new TaskWindow();
        if (window.ShowDialog() == true)
        {
            service.AddTask(window.Task);
            Tasks.Add(window.Task);
        }
    }

    private void EditTask()
    {
        if (SelectedTask == null) return;

        var taskCopy = new TaskItem
        {
            Title = SelectedTask.Title,
            Status = SelectedTask.Status,
            Priority = SelectedTask.Priority
        };

        var window = new TaskWindow(taskCopy);
        if (window.ShowDialog() == true)
        {
            SelectedTask.Title = window.Task.Title;
            SelectedTask.Status = window.Task.Status;
            SelectedTask.Priority = window.Task.Priority;

            service.UpdateTask(SelectedTask);
        }
    }

    private void DeleteTask()
    {
        if (SelectedTask == null) return;

        if (MessageBox.Show($"Удалить задачу \"{SelectedTask.Title}\"?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            service.DeleteTask(SelectedTask);
            Tasks.Remove(SelectedTask);
        }
    }
}