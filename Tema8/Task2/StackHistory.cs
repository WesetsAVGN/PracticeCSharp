namespace PracticeTasks;

class StackHistory<T>
{
    private MyStack<T> stack = new();

    public void Add(T item)
    {
        stack.Push(item);
    }

    public T Undo()
    {
        return stack.Pop();
    }

    public int Count()
    {
        return stack.Count();
    }
}