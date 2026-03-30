namespace PracticeTasks;

class AsiaTax : ITaxStrategy
{
    public double Calculate(double amount)
    {
        return amount * 0.15;
    }
}