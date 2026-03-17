Console.Write("Введите x: ");
double x = Convert.ToDouble(Console.ReadLine());

double y;

if ((x >= 1) && (x <= 3))
{
    y = (2 * x * x) - (3 * Math.Exp(Math.Sin(x)));
}
else
{
    y = 3 * Math.Tan(x);
}

Console.WriteLine($"y = {y:F4}");