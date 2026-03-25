class Calculator
{
    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivisionByZeroException("Деление на ноль запрещено");
        }

        return a / b;
    }
}