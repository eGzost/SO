using OS.Lab3;
using OS.Lab3.Abstractions;

Console.WriteLine("Patisserie producer-consumer model");

RandomLoadBalancer<string> bus = new();
Random random = new();

void CreateProducer(IBus<string> bus, int interval, string product)
{
    System.Timers.Timer timer = new()
    {
        Interval = interval,
        AutoReset = true,
    };
    timer.Elapsed += (_source, _event) =>
    {
        Console.WriteLine($"{product} produced");
        bus.Publish(product);
    };
    timer.Start();
}

void CreatePatisserieConsumer(IBus<string> bus, int number)
{
    bus.Subscribe((product) =>
    {
        Console.WriteLine($"Patisserie {number} received {product}");
    });
}

for (int i = 1; i < 6; i++)
{
    CreatePatisserieConsumer(bus, i);
}

List<string> products = ["Dought", "Sugar", "Eggs"];
products.ForEach((product) => CreateProducer(bus, random.Next(4000, 6000), product));

Console.WriteLine("Ctrl + C to stop the simulation");
// Keeps main thread alive
var exitEvent = new ManualResetEvent(false);
exitEvent.WaitOne();