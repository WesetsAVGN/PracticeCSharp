using System.Text;

Console.Write("Введите строку: ");
string txt = Console.ReadLine();

Console.Write("Начало (число): ");
int start = Convert.ToInt32(Console.ReadLine());

Console.Write("Длина (число): ");
int length = Convert.ToInt32(Console.ReadLine());

var sb = new StringBuilder(txt);

sb.Remove(start, length);

Console.WriteLine(sb.ToString());