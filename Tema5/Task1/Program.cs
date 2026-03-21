using System;
abstract class PaymentMethod
{
    public abstract void Pay(double amount);
}

class CreditCard : PaymentMethod
{
    public override void Pay(double amount)
    {
        Console.WriteLine($"Оплата картой: {amount:F2}");
    }
}

class PayPal : PaymentMethod
{
    public override void Pay(double amount)
    {
        Console.WriteLine($"Оплата PayPal: {amount:F2}");
    }
}

class Cash : PaymentMethod
{
    public override void Pay(double amount)
    {
        Console.WriteLine($"Оплата наличными: {amount:F2}");
    }
}

class Program
{
    static void Main()
    {
        PaymentMethod[] methods =
        [
            new CreditCard(),
            new PayPal(),
            new Cash()
        ];

        foreach (PaymentMethod method in methods)
        {
            method.Pay(100);
        }
    }
}