class NumProc
{
    public int Process(string input)
    {
        try
        {
            StringParser parser = new();
            return parser.ParseToInt(input);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Лог ошибки:");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

            throw new InvalidNumberException("Ошибка преобразования", ex);
        }
    }
}