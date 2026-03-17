Console.Write("a = ");
double a = Convert.ToDouble(Console.ReadLine());

Console.Write("b = ");
double b = Convert.ToDouble(Console.ReadLine());

double result = a * b;

Console.WriteLine($"{a:F1} * {b:F1} = {result:F1}");