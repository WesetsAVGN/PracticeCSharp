namespace PracticeTasks;

class EUTax : ITaxStrategy
{
    public double Calculate(double amount)
    {
        return amount * 0.2;
    }
}