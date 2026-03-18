Console.Write("Введите строку: ");
string txt = Console.ReadLine();

bool isValid = !string.IsNullOrEmpty(txt) && (char.IsLetter(txt[0]) || txt[0] == '_');

for (var i = 1; i < txt.Length && isValid; i++)
{
    if (!char.IsLetterOrDigit(txt[i]) && txt[i] != '_')
    {
        isValid = false;
    }
}

Console.WriteLine(isValid);