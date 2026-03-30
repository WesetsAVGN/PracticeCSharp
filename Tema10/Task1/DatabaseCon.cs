using System;

namespace PracticeTasks;

class DatabaseConnection
{
    private static DatabaseConnection instance;

    private DatabaseConnection()
    {
    }

    public static DatabaseConnection GetInstance()
    {
        if (instance == null)
        {
            instance = new DatabaseConnection();
        }

        return instance;
    }

    public void Connect()
    {
        Console.WriteLine("Подключение к БД установлено.");
    }

    public void Disconnect()
    {
        Console.WriteLine("Соединение закрыто.");
    }

    public void ExecuteQuery(string query)
    {
        Console.WriteLine($"Выполнение: {query}");
    }
}