using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManager;

public class TaskModel : INotifyPropertyChanged
{
    private string title;
    private string status;
    private string priority;

    public string Title
    {
        get => title;
        set { title = value; OnPropertyChanged(nameof(Title)); }
    }

    public string Status
    {
        get => status;
        set { status = value; OnPropertyChanged(nameof(Status)); }
    }

    public string Priority
    {
        get => priority;
        set { priority = value; OnPropertyChanged(nameof(Priority)); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}


