using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager;

public class TaskService
{
    private readonly List<TaskItem> tasks = new();

    public TaskService()
    {
        tasks.Add(new TaskItem { Title = "Тема 12", Status = "Выполнено", Priority = "Низкий" });
        tasks.Add(new TaskItem { Title = "Тема 13", Status = "Выполнено", Priority = "Низкий" });
        tasks.Add(new TaskItem { Title = "Тема 14", Status = "Выполнено", Priority = "Низкий" });
        tasks.Add(new TaskItem { Title = "Тема 15", Status = "В работе", Priority = "Высокий" });
        tasks.Add(new TaskItem { Title = "Тема 16", Status = "Отложено", Priority = "Низкий" });
    }

    public async Task<List<TaskItem>> LoadTasksAsync()
    {
        await Task.Delay(2000);
        return tasks.ToList();
    }

    public void AddTask(TaskItem task)
    {
        tasks.Add(task);
    }

    public void UpdateTask(TaskItem task)
    {
        var existing = tasks.FirstOrDefault(t => t == task);
        if (existing != null)
        {
            existing.Title = task.Title;
            existing.Status = task.Status;
            existing.Priority = task.Priority;
        }
    }

    public void DeleteTask(TaskItem task)
    {
        tasks.Remove(task);
    }
}