namespace OS.Lab4.Contracts;

public record TaskRequest(
    int TaskId,
    string TaskDescription,
    MailboxConsumer<TaskCompletedResponse> Owner
);