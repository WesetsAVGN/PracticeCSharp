public class InsufFundsExcept : Exception
{
    public InsufFundsExcept()
    {
    }

    public InsufFundsExcept(string message) : base(message)
    {
    }

    public InsufFundsExcept(string message, Exception inner) : base(message, inner)
    {
    }
}