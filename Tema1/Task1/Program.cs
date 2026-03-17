Console.Write("Введите расстояние (м): ");
int m = Convert.ToInt32(Console.ReadLine());

int km = m / 1000;

Console.WriteLine($"Полных километров: {km}");