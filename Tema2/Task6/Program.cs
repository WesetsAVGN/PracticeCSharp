Console.Write("Введите строку: ");
string txt = Console.ReadLine();

char[] result = new char[txt.Length];
int index = 0;

foreach (char ch in txt)
{
    if (!char.IsPunctuation(ch))
    {
        result[index] = ch;
        index++;
    }
}

string clear = new string(result, 0, index);

Console.WriteLine(clear);