namespace OS.Lab2;

public class MyStack<T>
{
    private readonly List<T> items = [];

    public int Count => items.Count;

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        int lastIndex = items.Count - 1;
        T poppedItem = items[lastIndex];
        items.RemoveAt(lastIndex);
        return poppedItem;
    }

    public T Peek()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return items[^1];
    }

    public void Clear()
    {
        items.Clear();
    }

    public bool IsEmpty => Count == 0;

    public override string ToString() => $"[{string.Join(", ", items)}]";
}
