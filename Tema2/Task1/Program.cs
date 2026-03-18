Console.Write("Введите размер массива: ");
int n = Convert.ToInt32(Console.ReadLine());

double[] array = new double[n];

for (var i = 0; i < n; i++)
{
    Console.Write($"a[{i}] = ");
    array[i] = Convert.ToDouble(Console.ReadLine());
}

double sum = 0;

for (var i = 0; i < n; i++)
{
    sum += array[i];
}

double avg = sum / n;
Console.WriteLine($"Среднее: {avg:F4}");