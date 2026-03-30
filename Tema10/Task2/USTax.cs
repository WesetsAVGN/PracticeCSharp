namespace PracticeTasks;

class USTax : ITaxStrategy
{
    public double Calculate(double amount)
    {
        return amount * 0.1;
    }
}