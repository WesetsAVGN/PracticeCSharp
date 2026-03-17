Console.Write("Введите alpha (в рад): ");
double alpha = Convert.ToDouble(Console.ReadLine());

Console.Write("Введите beta (в рад): ");
double beta = Convert.ToDouble(Console.ReadLine());

double z1 = (Math.Sin(alpha) + Math.Cos((2 * beta) - alpha)) / (Math.Cos(alpha) - Math.Sin((2 * beta) - alpha));

double z2 = (1 + Math.Sin(2 * beta)) / Math.Cos(2 * beta);

Console.WriteLine($"z1 = {z1:F4}");
Console.WriteLine($"z2 = {z2:F4}");