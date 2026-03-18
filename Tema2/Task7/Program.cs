Console.Write("Введите строку: ");
string txt = Console.ReadLine();

string[] words = txt.Split(' ');

foreach (string word in words)
{
    Console.WriteLine(word);
}