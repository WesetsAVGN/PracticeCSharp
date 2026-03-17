double x = 4.3;

double y = (1 + Math.Sqrt(Math.Abs(3 - (x * x)))) / Math.Atan(x * x) - Math.Exp(Math.Sin(Math.Sqrt(x)));

Console.WriteLine($"x = {x}");
Console.WriteLine($"y = {y:F4}");