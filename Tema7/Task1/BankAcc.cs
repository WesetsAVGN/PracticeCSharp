class BankAcc
{
    public decimal Balance { get; set; }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InsufFundsExcept("Недостаточно средств");
        }

        Balance -= amount;
    }
}