Console.Write("A: ");
int a = Convert.ToInt32(Console.ReadLine());

Console.Write("B: ");
int b = Convert.ToInt32(Console.ReadLine());

Console.Write("X: ");
int x = Convert.ToInt32(Console.ReadLine());

Console.Write("Y: ");
int y = Convert.ToInt32(Console.ReadLine());

for (var i = a; i <= b; i++)
{
    int last = i % 10;

    if ((last == x) || (last == y))
    {
        Console.WriteLine(i);
    }
}

int j = a;
while (j <= b)
{
    int last = j % 10;

    if ((last == x) || (last == y))
    {
        Console.WriteLine(j);
    }

    j++;
}

int k = a;
do
{
    int last = k % 10;

    if ((last == x) || (last == y))
    {
        Console.WriteLine(k);
    }

    k++;
}
while (k <= b);