using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskManager;

public class TaskManagerViewModel : TaskModel
{
    private readonly TaskRepository repository = new();
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
        }
    }

    private bool isLoading;
    public bool IsLoading
    {
        get => isLoading;
        set
        {
            isLoading = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddTaskCommand { get; }
    public ICommand EditTaskCommand { get; }
    public ICommand DeleteTaskCommand { get; }

    public TaskManagerViewModel(string username)
    {
        this.username = username;

        AddTaskCommand = new RelayCommand(async () => await AddTaskAsync());
        EditTaskCommand = new RelayCommand(async () => await EditTaskAsync(), () => SelectedTask != null);
        DeleteTaskCommand = new RelayCommand(async () => await DeleteTaskAsync(), () => SelectedTask != null);
    }

    public async Task LoadTasksAsync()
    {
        IsLoading = true;

        await Task.Delay(200);

        await repository.InitAsync();

        var list = await repository.GetTasksAsync(username);

        Tasks.Clear();
        foreach (var t in list)
            Tasks.Add(t);

        IsLoading = false;
    }

    private async Task AddTaskAsync()
    {
        var window = new TaskWindow();

        if (window.ShowDialog() == true)
        {
            await repository.AddTaskAsync(username, window.Task);
            await LoadTasksAsync();
        }
    }

    private async Task EditTaskAsync()
    {
        if (SelectedTask == null) return;

        var copy = new TaskItem
        {
            Id = SelectedTask.Id,
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

            await repository.UpdateTaskAsync(SelectedTask);
            await LoadTasksAsync();
        }
    }

    private async Task DeleteTaskAsync()
    {
        if (SelectedTask == null) return;

        var result = System.Windows.MessageBox.Show("Удалить задачу?", "Подтверждение",
            System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning);

        if (result != System.Windows.MessageBoxResult.Yes)
            return;

        await repository.DeleteTaskAsync(SelectedTask);
        await LoadTasksAsync();
    }

    public async Task UpdateOrderAsync()
    {
        await repository.UpdateOrderAsync(Tasks.ToList());
    }
}