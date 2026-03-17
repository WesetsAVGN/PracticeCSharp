Console.Write("Введите двузначное число: ");
int num = Convert.ToInt32(Console.ReadLine());

int t = num / 10;
int o = num % 10;

int sum = t + o;

Console.WriteLine($"Сумма цифр: {sum}");