using System;
class Program
{
    static void Main()
    {
        BrowserHistory history = new();

        history.Visit(new Page { Url = "a.com", Title = "A" });
        history.Visit(new Page { Url = "b.com", Title = "B" });

        Page page = history.GoBack();

        Console.WriteLine(page?.Title);
    }
}