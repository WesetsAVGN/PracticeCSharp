using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TaskManager;

public class TaskRepository
{
    private readonly string dbPath = "app.db";
    private readonly string connectionString;

    public TaskRepository()
    {
        connectionString = $"Data Source={dbPath}";
    }

    public async Task InitAsync()
    {
        if (!File.Exists(dbPath))
        {
            using (File.Create(dbPath)) { }
        }

        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var cmd = connection.CreateCommand();
        cmd.CommandText = @"
        CREATE TABLE IF NOT EXISTS Tasks (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Title TEXT,
            Status TEXT,
            Priority TEXT,
            Username TEXT,
            OrderIndex INTEGER );";

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task<List<TaskItem>> GetTasksAsync(string username)
    {
        var list = new List<TaskItem>();

        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT Id, Title, Status, Priority, OrderIndex FROM Tasks WHERE Username = @user ORDER BY OrderIndex";
        cmd.Parameters.AddWithValue("@user", username);

        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(new TaskItem
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Status = reader.GetString(2),
                Priority = reader.GetString(3),
                Order = reader.GetInt32(4)
            });
        }

        return list;
    }

    public async Task AddTaskAsync(string username, TaskItem task)
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var cmd = connection.CreateCommand();
        cmd.CommandText = @"INSERT INTO Tasks (Title, Status, Priority, Username, OrderIndex) VALUES (@t, @s, @p, @u, (SELECT IFNULL(MAX(OrderIndex),0)+1 FROM Tasks WHERE Username=@u))";

        cmd.Parameters.AddWithValue("@t", task.Title);
        cmd.Parameters.AddWithValue("@s", task.Status);
        cmd.Parameters.AddWithValue("@p", task.Priority);
        cmd.Parameters.AddWithValue("@u", username);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var cmd = connection.CreateCommand();
        cmd.CommandText = @"UPDATE Tasks SET Title = @t, Status = @s, Priority = @p WHERE Id = @id";

        cmd.Parameters.AddWithValue("@t", task.Title);
        cmd.Parameters.AddWithValue("@s", task.Status);
        cmd.Parameters.AddWithValue("@p", task.Priority);
        cmd.Parameters.AddWithValue("@id", task.Id);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task DeleteTaskAsync(TaskItem task)
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var cmd = connection.CreateCommand();
        cmd.CommandText = "DELETE FROM Tasks WHERE Id = @id";
        cmd.Parameters.AddWithValue("@id", task.Id);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task UpdateOrderAsync(List<TaskItem> tasks)
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        for (int i = 0; i < tasks.Count; i++)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Tasks SET OrderIndex = @o WHERE Id = @id";
            cmd.Parameters.AddWithValue("@o", i);
            cmd.Parameters.AddWithValue("@id", tasks[i].Id);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}