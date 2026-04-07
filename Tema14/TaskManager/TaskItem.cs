using System.ComponentModel;

namespace TaskManager;

public class TaskItem : INotifyPropertyChanged
{
    private string title;
    private string status;
    private string priority;
    private string deadline;

    public string Title
    {
        get => title;
        set
        {
            title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    public string Status
    {
        get => status;
        set
        {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

    public string Priority
    {
        get => priority;
        set
        {
            priority = value;
            OnPropertyChanged(nameof(Priority));
        }
    }

    public string Deadline
    {
        get => deadline;
        set
        {
            deadline = value;
            OnPropertyChanged(nameof(Deadline));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}