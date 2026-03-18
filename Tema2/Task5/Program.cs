int[][] array =
[
    [1, -1],
    [2, 3],
    [0, 0],
    [5]
];

foreach (int[] row in array)
{
    int sum = 0;

    foreach (int item in row)
    {
        sum += item;
    }

    if (sum != 0)
    {
        foreach (int item in row)
        {
            Console.Write($"{item} ");
        }

        Console.WriteLine();
    }
}