using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TaskManager;

public partial class MainWindow : Window
{
    private List<TaskItem> tasks = [];

    public ICommand AddTaskCommand { get; }
    public ICommand EditTaskCommand { get; }
    public ICommand DeleteTaskCommand { get; }

    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;

        AddTaskCommand = new RelayCommand(AddTask);
        EditTaskCommand = new RelayCommand(EditTask, () => TaskList.SelectedItem != null);
        DeleteTaskCommand = new RelayCommand(DeleteTask, () => TaskList.SelectedItem != null);

        TaskList.SelectionChanged += (s, e) =>
        {
            CommandManager.InvalidateRequerySuggested();
        };

        StatusFilter.SelectedIndex = 0;

        InputBindings.Add(new KeyBinding(AddTaskCommand, new KeyGesture(Key.N, ModifierKeys.Control)));
        InputBindings.Add(new KeyBinding(EditTaskCommand, new KeyGesture(Key.E, ModifierKeys.Control)));
        InputBindings.Add(new KeyBinding(DeleteTaskCommand, new KeyGesture(Key.D, ModifierKeys.Control)));
    }

    private void AddTask()
    {
        TaskWindow window = new();

        if (window.ShowDialog() == true)
        {
            tasks.Add(window.Task);
            UpdateList();
        }
    }

    private void EditTask()
    {
        if (TaskList.SelectedIndex < 0)
        {
            return;
        }

        TaskItem selected = tasks[TaskList.SelectedIndex];

        TaskWindow window = new(selected);

        if (window.ShowDialog() == true)
        {
            tasks[TaskList.SelectedIndex] = window.Task;
            UpdateList();
        }
    }

    private void DeleteTask()
    {
        if (TaskList.SelectedIndex < 0)
        {
            return;
        }

        var result = MessageBox.Show(
            "Удалить задачу?",
            "Подтверждение",
            MessageBoxButton.YesNo);

        if (result == MessageBoxResult.Yes)
        {
            tasks.RemoveAt(TaskList.SelectedIndex);
            UpdateList();
        }
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleBox.Text))
        {
            return;
        }

        tasks.Add(new TaskItem
        {
            Title = TitleBox.Text,
            Priority = (PriorityBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
            Status = (StatusBox.SelectedItem as ComboBoxItem)?.Content.ToString()
        });

        UpdateList();
    }

    private void StatusFilter_Changed(object sender, SelectionChangedEventArgs e)
    {
        UpdateList();
    }

    private void UpdateList()
    {
        TaskList.Items.Clear();

        string filter = (StatusFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

        var filtered = tasks;

        if (filter != "Все")
        {
            filtered = tasks
                .Where(t => t.Status == filter)
                .ToList();
        }

        foreach (TaskItem t in filtered)
        {
            TaskList.Items.Add($"{t.Title} | {t.Status} | {t.Priority}");
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