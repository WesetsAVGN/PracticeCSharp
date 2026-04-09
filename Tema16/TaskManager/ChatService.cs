using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace TaskManager;

public class ChatService
{
    public event System.Action<string>? OnMessageReceived;

    public async Task StartServerAsync()
    {
        while (true)
        {
            var server = new NamedPipeServerStream("task_chat");
            await server.WaitForConnectionAsync();

            using var reader = new StreamReader(server);
            string message = await reader.ReadLineAsync();

            OnMessageReceived?.Invoke(message);
        }
    }

    public async Task SendMessageAsync(string message)
    {
        using var client = new NamedPipeClientStream(".", "task_chat", PipeDirection.Out);
        await client.ConnectAsync();

        using var writer = new StreamWriter(client) { AutoFlush = true };
        await writer.WriteLineAsync(message);
    }
}