namespace PracticeTasks;

abstract class TextDecorator : IText
{
    protected IText component;

    protected TextDecorator(IText component)
    {
        this.component = component;
    }

    public abstract string GetContent();
}