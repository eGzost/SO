namespace OS.Lab4.Contracts;

public record TaskCompletedResponse(
    int TaskId,
    string WorkerName
);