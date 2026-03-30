using System.ComponentModel;

namespace PracticeTasks;

class BoldDecorator : TextDecorator
{
    public BoldDecorator(IText component) : base(component)
    {
    }

    public override string GetContent()
    {
        return $"<b>{component.GetContent()}</b>";
    }
}