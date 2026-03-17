Console.Write("Введите признак (а, в, м, с, п): ");
char type = Convert.ToChar(Console.ReadLine());

switch (type)
{
    case 'а':
        Console.WriteLine("120 км/ч");
        break;

    case 'в':
        Console.WriteLine("25 км/ч");
        break;

    case 'м':
        Console.WriteLine("78 км/ч");
        break;

    case 'с':
        Console.WriteLine("840 км/ч");
        break;

    case 'п':
        Console.WriteLine("170 км/ч");
        break;

    default:
        Console.WriteLine("букву выбрать надо");
        break;
}