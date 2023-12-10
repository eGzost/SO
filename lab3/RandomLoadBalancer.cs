namespace OS.Lab3;

using System.Diagnostics;
using OS.Lab3.Abstractions;

public class RandomLoadBalancer<MessageT> : IBus<MessageT>
{
    private readonly List<Action<MessageT>> subscribers = [];
    private readonly Random random = new();

    public void Publish(MessageT message)
    {
        if (subscribers.Count == 0)
        {
            Debug.WriteLine("{} is empty, no one consumed the message", nameof(RandomLoadBalancer<MessageT>));
        }
        int consumerIndex = random.Next(0, subscribers.Count - 1);
        subscribers[consumerIndex](message);
    }

    public void Subscribe(Action<MessageT> callback)
    {
        subscribers.Add(callback);
    }

    public void Unsubscribe(Action<MessageT> callback)
    {
        subscribers.Remove(callback);
    }
}