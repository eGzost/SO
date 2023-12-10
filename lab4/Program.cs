using OS.Common;
using OS.Lab4;
using OS.Lab4.Contracts;

var bus = new RandomLoadBalancer<TaskRequest>();

ProcessController processController = new(bus);

List<ProcessWorker> workers = Enumerable
    .Range(1, 3)
    .Select(workerId => new ProcessWorker(workerId))
    .ToList();

foreach (var worker in workers)
{
    bus.Subscribe(worker.PostMessage);
}

Console.WriteLine("Press Ctrl + C to stop the simulation");
// Keeps main thread alive
var exitEvent = new ManualResetEvent(false);
exitEvent.WaitOne();