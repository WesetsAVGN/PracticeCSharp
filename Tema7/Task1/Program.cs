using System;
class Program
{
    static void Main()
    {
        BankAcc account = new()
        {
            Balance = 100
        };

        try
        {
            account.Withdraw(200);
        }
        catch (InsufFundsExcept ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}