double a = 0;
double b = Math.PI / 4;
int m = 10;

double h = (b - a) / m;

for (var i = 0; i <= m; i++)
{
    double x = a + (i * h);
    double y = Math.Tan(x);

    Console.WriteLine($"x={x:F4} y={y:F4}");
}