using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskManager;

public class TaskService
{
    private const string FileName = "tasks.json";

    public async Task<List<TaskItem>> LoadTasksAsync(string username)
    {
        await Task.Delay(500);

        if (!File.Exists(FileName))
            return new List<TaskItem>();

        var json = await File.ReadAllTextAsync(FileName);
        var all = JsonSerializer.Deserialize<List<UserTasks>>(json) ?? new();

        return all.FirstOrDefault(u => u.Username == username)?.Tasks ?? new List<TaskItem>();
    }

    public async void SaveTasks(string username, List<TaskItem> tasks)
    {
        List<UserTasks> all;

        if (File.Exists(FileName))
        {
            var json = await File.ReadAllTextAsync(FileName);
            all = JsonSerializer.Deserialize<List<UserTasks>>(json) ?? new();
        }
        else
        {
            all = new List<UserTasks>();
        }

        var user = all.FirstOrDefault(u => u.Username == username);

        if (user == null)
        {
            user = new UserTasks { Username = username };
            all.Add(user);
        }

        user.Tasks = tasks;

        var newJson = JsonSerializer.Serialize(all, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(FileName, newJson);
    }
}