namespace PracticeTasks;

class Program
{
    static void Main()
    {
        var db1 = DatabaseConnection.GetInstance();
        var db2 = DatabaseConnection.GetInstance();

        db1.Connect();
        db1.ExecuteQuery("SELECT * FROM Users");
        db2.Disconnect();
    }
}