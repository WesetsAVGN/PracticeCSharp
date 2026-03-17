Console.Write("Введите число: ");
int num = Convert.ToInt32(Console.ReadLine());

bool isTrue = (num >= 10) && (num <= 99) && (num % 2 == 0);

Console.WriteLine(isTrue);