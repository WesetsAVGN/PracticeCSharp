for (var i = 10; i <= 99; i++)
{
    int t = i / 10;
    int o = i % 10;

    int sum = (t * t) + (o * o);

    if (sum % 13 == 0)
    {
        Console.WriteLine(i);
    }
}