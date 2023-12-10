namespace OS.Lab3.Abstractions;

public interface IBus<MessageT>
{
    public void Subscribe(Action<MessageT> callback);
    public void Unsubscribe(Action<MessageT> callback);
    public void Publish(MessageT message);
}