using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TaskManager;

public partial class TaskWindow : Window
{
    public TaskItem Task { get; private set; }

    public TaskWindow(TaskItem? task = null)
    {
        InitializeComponent();

        if (task != null)
        {
            TitleBox.Text = task.Title;
            SelectCombo(PriorityBox, task.Priority);
            SelectCombo(StatusBox, task.Status);
        }
    }

    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        Task = new TaskItem
        {
            Title = TitleBox.Text,
            Priority = (PriorityBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
            Status = (StatusBox.SelectedItem as ComboBoxItem)?.Content.ToString()
        };

        DialogResult = true;
    }

    private void SelectCombo(ComboBox combo, string value)
    {
        foreach (ComboBoxItem item in combo.Items)
        {
            if (item.Content.ToString() == value)
            {
                combo.SelectedItem = item;
                break;
            }
        }
    }
}