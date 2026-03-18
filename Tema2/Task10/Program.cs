using System.Text.RegularExpressions;

Console.Write("Введите строку: ");
string text = Console.ReadLine();

bool hasUp = Regex.IsMatch(text, "[A-Z, А-Я]");

Console.WriteLine(hasUp);