using System.ComponentModel;

namespace PracticeTasks;

class ItalicDecorator : TextDecorator
{
    public ItalicDecorator(IText component) : base(component)
    {
    }

    public override string GetContent()
    {
        return $"<i>{component.GetContent()}</i>";
    }
}