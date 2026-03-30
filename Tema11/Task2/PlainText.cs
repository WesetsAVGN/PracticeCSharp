namespace PracticeTasks;

class PlainText : IText
{
    private string text;

    public PlainText(string text)
    {
        this.text = text;
    }

    public string GetContent()
    {
        return text;
    }
}