Console.Write("Введите трехзначное число: ");
int num = Convert.ToInt32(Console.ReadLine());

int hund = num / 100;
int ostatok = num % 100;

int result = (ostatok * 10) + hund;

Console.WriteLine($"Полученное число: {result}");