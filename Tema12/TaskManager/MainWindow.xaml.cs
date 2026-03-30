using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TaskManager;

public partial class MainWindow : Window
{
    private List<TaskItem> tasks = [];

    public MainWindow()
    {
        InitializeComponent();

        StatusFilter.SelectedIndex = 0;
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
}