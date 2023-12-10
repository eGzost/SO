// See https://aka.ms/new-console-template for more information
using OS.Lab2;

Console.WriteLine("Stack reversal:");

int[] integers = [1, 4, 5, 10, 5, 12];

MyStack<int> originalStack = new();
MyStack<int> reversedStack = new();

foreach (int integer in integers)
{
    originalStack.Push(integer);
}

Console.WriteLine("Original stack:");
Console.WriteLine(originalStack);

while (!originalStack.IsEmpty)
{
    reversedStack.Push(originalStack.Pop());
}

Console.WriteLine("Reversed stack:");
Console.WriteLine(reversedStack);