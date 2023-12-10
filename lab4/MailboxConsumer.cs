namespace OS.Lab4;

public abstract class MailboxConsumer<MessageT>
{
    protected readonly System.Timers.Timer mailboxTimer = new()
    {
        Interval = 1000,
        AutoReset = true
    };
    protected List<MessageT> mailbox = [];
    public void PostMessage(MessageT message)
    {
        mailbox.Add(message);
    }
}