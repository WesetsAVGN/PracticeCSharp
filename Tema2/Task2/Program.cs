Console.Write("Введите n: ");
int n = Convert.ToInt32(Console.ReadLine());

double[] array = new double[n];
Random rnd = new();


for (var i = 0; i < n; i++)
{
    array[i] = Math.Round(rnd.NextDouble() * 26 - 5, 2);
}

double sum = 0;

for (var i = 0; i < n; i++)
{
    sum += array[i];
}

double avg = sum / n;

for (var i = 0; i < n; i++)
{
    if (array[i] < 0)
    {
        array[i] += 0.5;
    }
    else if (array[i] < avg)
    {
        array[i] = 0.1;
    }
}

Array.Sort(array);

Console.WriteLine("Отсортированный массив:");
foreach (double item in array)
{
    Console.WriteLine($"{item:F4}");
}

Console.Write("Введите k: ");
double k = Convert.ToDouble(Console.ReadLine());

int l = 0;
int r = n - 1;
int index = -1;

while (l <= r)
{
    int mid = (l + r) / 2;

    if (array[mid] == k)
    {
        index = mid;
        break;
    }

    if (array[mid] < k)
    {
        l = mid + 1;
    }
    else
    {
        r = mid - 1;
    }
}

Console.WriteLine($"Индекс: {index}");