int[,] dohod = new int[10, 12];
Random rnd = new();

for (var i = 0; i < 10; i++)
{
    for (var j = 0; j < 12; j++)
    {
        dohod[i, j] = rnd.Next(1000, 5000);
    }
}

int sept = 0;

for (var i = 0; i < 10; i++)
{
    sept += dohod[i, 8];
}

Console.Write("Введите число: ");
int val = Convert.ToInt32(Console.ReadLine());

bool result = sept > val;

Console.WriteLine(result);