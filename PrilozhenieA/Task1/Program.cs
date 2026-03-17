Console.WriteLine("Введите исходные данные:");

Console.Write("Цена тетради (руб.) -> ");
double noteP = Convert.ToDouble(Console.ReadLine());

Console.Write("Количество тетрадей -> ");
int noteC = Convert.ToInt16(Console.ReadLine());

Console.Write("Цена карандаша (руб.) -> ");
double penP = Convert.ToDouble(Console.ReadLine());

Console.Write("Количество карандашей -> ");
int PenC = Convert.ToInt16(Console.ReadLine());

double total = (noteP * noteC) + (penP * PenC);

Console.WriteLine($"Стоимость покупки: {total:F2} руб.");