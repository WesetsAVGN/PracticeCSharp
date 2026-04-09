using System.Text.Json;
using System.Windows;
using System.IO;

namespace TaskManager;

public partial class LoginWindow : Window
{
    public string Username { get; private set; }

    private const string FileName = "users.json";

    public LoginWindow()
    {
        InitializeComponent();
    }

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        var username = UserBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(username))
        {
            MessageBox.Show("Введите имя");
            return;
        }

        var users = Load();

        if (!users.Contains(username))
        {
            users.Add(username);
            Save(users);
        }

        Username = username;
        DialogResult = true;
    }

    private List<string> Load()
    {
        if (!File.Exists(FileName)) return new();
        return JsonSerializer.Deserialize<List<string>>(File.ReadAllText(FileName)) ?? new();
    }

    private void Save(List<string> users)
    {
        File.WriteAllText(FileName,
            JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));
    }
}