using System.Collections;
class BrowserHistory
{
    private Stack backStack = new();
    private Stack forwardStack = new();

    public void Visit(Page page)
    {
        backStack.Push(page);
        forwardStack.Clear();
    }

    public Page GoBack()
    {
        if (backStack.Count <= 1)
        {
            return null;
        }

        Page current = (Page)backStack.Pop();
        forwardStack.Push(current);

        return (Page)backStack.Peek();
    }

    public Page GoForward()
    {
        if (forwardStack.Count == 0)
        {
            return null;
        }

        Page page = (Page)forwardStack.Pop();
        backStack.Push(page);

        return page;
    }
}