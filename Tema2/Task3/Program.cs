Console.Write("Введите N (<10): ");
int n = Convert.ToInt32(Console.ReadLine());

Console.Write("a: ");
int a = Convert.ToInt32(Console.ReadLine());

Console.Write("b: ");
int b = Convert.ToInt32(Console.ReadLine());

int[,] matrix = new int[n, n];
Random rnd = new();

for (var i = 0; i < n; i++)
{
    for (var j = 0; j < n; j++)
    {
        matrix[i, j] = rnd.Next(a, b + 1);
        Console.Write($"{matrix[i, j]} ");
    }

    Console.WriteLine();
}

Console.Write("Введите C: ");
int c = Convert.ToInt32(Console.ReadLine());

int sum = 0;

for (var i = 0; i < n; i++)
{
    for (var j = 0; j < n; j++)
    {
        if (matrix[i, j] > c)
        {
            sum += matrix[i, j] * matrix[i, j];
        }
    }
}

Console.WriteLine($"Сумма квадратов: {sum}");

for (var i = 0; i < n; i++)
{
    int rowSum = 0;

    for (var j = 0; j < n; j++)
    {
        rowSum += matrix[i, j];
    }

    double avg = (double)rowSum / n;
    Console.WriteLine($"Среднее строки {i}: {avg:F2}");
}