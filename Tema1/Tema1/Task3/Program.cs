Console.Write("Введите цену за 1 кг: ");
int price = Convert.ToInt32(Console.ReadLine());

for (var i = 1; i <= 10; i++)
{
    int cost = i * price;
    Console.WriteLine($"{i} кг = {cost}");
}