using System.Threading.Tasks;
using System.Windows;

namespace TaskManager;

public partial class ChatWindow : Window
{
    private readonly ChatService chat = new();
    private string lastMessage = "";

    public ChatWindow()
    {
        InitializeComponent();

        chat.OnMessageReceived += msg =>
        {
            Dispatcher.Invoke(() =>
            {
                if (msg == lastMessage) return;

                MessagesBox.Items.Add(msg);
            });
        };

        _ = chat.StartServerAsync();
    }

    private async void Send_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(MessageInput.Text)) return;

        string msg = MessageInput.Text;

        lastMessage = msg;

        MessagesBox.Items.Add("Я: " + msg);

        await chat.SendMessageAsync(msg);

        MessageInput.Clear();
    }
}