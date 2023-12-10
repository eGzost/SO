using OS.Lab4.Contracts;

namespace OS.Lab4;

public class ProcessWorker : MailboxConsumer<TaskRequest>
{
    private readonly int workerId;
    public ProcessWorker(int workerId)
    {
        this.workerId = workerId;
        StartMonitoring();
    }
    private readonly Random random = new();
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
                var todo = mailbox[0];
                mailbox.Remove(todo);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Worker {workerId} started work on task {todo.TaskId}");
                Console.ResetColor();
                Task.Run(async () =>
                {
                    await Task.Delay(random.Next(500, 1000));
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Worker {workerId} finished work on task {todo.TaskId}");
                    Console.ResetColor();
                    todo.Owner.PostMessage(new TaskCompletedResponse(
                        todo.TaskId,
                        $"Worker {workerId}"
                    ));
                });
            }
        };
        mailboxTimer.Start();
    }
}