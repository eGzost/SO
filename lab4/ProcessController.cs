using OS.Common.Abstractions;
using OS.Lab4.Contracts;

namespace OS.Lab4;

public class ProcessController : MailboxConsumer<TaskCompletedResponse>
{
    public ProcessController(IBus<TaskRequest> bus)
    {
        mailboxTimer.Interval = 3000;
        int taskId = 1;
        // publishes tasks for the workers
        System.Timers.Timer timer = new()
        {
            Interval = 1500,
            AutoReset = true,
            Enabled = true,
        };
        timer.Elapsed += (_, _) =>
        {
            bus.Publish(new TaskRequest(
                taskId,
                "Do some work",
                this
            ));
            taskId++;
        };
        StartMonitoring();
    }

    private void StartMonitoring()
    {
        if (mailboxTimer.Enabled)
        {
            return;
        }
        mailboxTimer.Elapsed += (_, _) =>
        {
            if (mailbox.Count != 0)
            {
                lock (mailbox)
                {
                    Console.WriteLine($"Controller acknowledged completed tasks: {string.Join(", ", mailbox.Select(x => x.TaskId))}");
                    mailbox.Clear();
                }
            }
        };
        mailboxTimer.Start();
    }
}