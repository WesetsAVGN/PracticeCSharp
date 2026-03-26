using System;

namespace PracticeTasks;

class MyStack<T>
{
    private T[] items = new T[10];
    private int count;

    public void Push(T item)
    {
        items[count++] = item;
    }

    public T Pop()
    {
        return items[--count];
    }

    public T Peek()
    {
        return items[count - 1];
    }

    public int Count()
    {
        return count;
    }
}