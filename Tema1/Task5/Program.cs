Console.Write("Введите M: ");
int m = Convert.ToInt32(Console.ReadLine());

Console.Write("Введите N: ");
int n = Convert.ToInt32(Console.ReadLine());

if ((n != 0) && (m % n == 0))
{
    int result = m / n;
    Console.WriteLine($"Частное: {result}");
}
else
{
    Console.WriteLine("M на N нацело не делится");
}