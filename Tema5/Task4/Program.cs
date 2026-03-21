using System;
interface ICreditPayment
{
    void ProcessPayment(decimal amount);
}

interface IDebitPayment
{
    void ProcessPayment(decimal amount);
}

class PaymentProcessor : ICreditPayment, IDebitPayment
{
    void ICreditPayment.ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Кредитный платеж: {amount:F2}");
    }

    void IDebitPayment.ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Дебетовый платеж: {amount:F2}");
    }
}

class Program
{
    static void Main()
    {
        PaymentProcessor processor = new();

        ICreditPayment credit = processor;
        IDebitPayment debit = processor;

        credit.ProcessPayment(100);
        debit.ProcessPayment(200);
    }
}