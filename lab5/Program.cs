using OS.Lab5;

int[] array = [10, 9, 8, 8, 7, 4, 70, 60, 50];

Console.WriteLine($"Original array: [{string.Join(", ", array)}]");

MaxHeap<int> heap = new();
foreach (int element in array)
{
    heap.Insert(element);
}
Console.WriteLine(heap);

int[] sortedArray = new int[heap.Count];
for (int i = heap.Count - 1; i >= 0; i--)
{
    sortedArray[i] = heap.ExtractMax();
}
Console.WriteLine($"Sorted array: [{string.Join(", ", sortedArray)}]");
