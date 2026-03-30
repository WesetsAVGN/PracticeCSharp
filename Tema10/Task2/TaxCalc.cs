namespace PracticeTasks;

class TaxCalculator
{
    private ITaxStrategy strategy;

    public void SetStrategy(ITaxStrategy strategy)
    {
        this.strategy = strategy;
    }

    public double Calculate(double amount)
    {
        return strategy.Calculate(amount);
    }
}