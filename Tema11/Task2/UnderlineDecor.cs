using System.ComponentModel;

namespace PracticeTasks;

class UnderlineDecorator : TextDecorator
{
    public UnderlineDecorator(IText component) : base(component)
    {
    }

    public override string GetContent()
    {
        return $"<u>{component.GetContent()}</u>";
    }
}