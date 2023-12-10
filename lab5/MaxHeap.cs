namespace OS.Lab5;

public class MaxHeap<T> where T : IComparable<T>
{
    private readonly List<T> items = [];

    public int Count => items.Count;

    public void Insert(T item)
    {
        items.Add(item);
        HeapifyUp(items.Count - 1);
    }

    public T ExtractMax()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        T root = items[0];
        items[0] = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);

        if (items.Count > 1)
        {
            HeapifyDown(0);
        }

        return root;
    }

    private void HeapifyUp(int index)
    {
        int parent = (index - 1) / 2;

        while (index > 0 && items[parent].CompareTo(items[index]) < 0)
        {
            Swap(parent, index);
            index = parent;
            parent = (index - 1) / 2;
        }
    }

    private void HeapifyDown(int index)
    {
        int leftChild;
        int rightChild;
        int largestChild;

        while (true)
        {
            leftChild = 2 * index + 1;
            rightChild = 2 * index + 2;
            largestChild = index;

            if (leftChild < items.Count && items[leftChild].CompareTo(items[largestChild]) > 0)
            {
                largestChild = leftChild;
            }

            if (rightChild < items.Count && items[rightChild].CompareTo(items[largestChild]) > 0)
            {
                largestChild = rightChild;
            }

            if (largestChild == index)
            {
                break;
            }

            Swap(index, largestChild);
            index = largestChild;
        }
    }

    private void Swap(int index1, int index2)
    {
        (items[index2], items[index1]) = (items[index1], items[index2]);
    }

    public override string ToString() => $"{nameof(MaxHeap<T>)}<{typeof(T).Name}>: [{string.Join(", ", items)}]";
}
