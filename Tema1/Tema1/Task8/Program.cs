Console.Write("Введите A: ");
double a = Convert.ToDouble(Console.ReadLine());

Console.Write("Введите N: ");
int n = Convert.ToInt32(Console.ReadLine());

double result = 1;

for (var i = 1; i <= n; i++)
{
    result *= a;
    Console.WriteLine($"{result:F4}");
}