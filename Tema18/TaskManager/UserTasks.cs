namespace TaskManager;
public class UserTasks
{
    public string Username { get; set; }
    public List<TaskItem> Tasks { get; set; } = new();
}