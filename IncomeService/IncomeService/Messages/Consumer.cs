using Confluent.Kafka;

namespace IncomeService.Messages;

public class Consumer
{
    public string Bruh(string topic)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true; // prevent the process from terminating.
            cts.Cancel();
        };

        var config = new ConsumerConfig
        {
            BootstrapServers = "bootstrap.servers=kafka.application.svc.cluster.local:9092",
            GroupId = "kafka-dotnet-getting-started",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        var message = "NONE";
        using var consumer = new ConsumerBuilder<string, string>(config).Build();
        consumer.Subscribe(topic);
        try
        {
            while (true)
            {
                var cr = consumer.Consume(cts.Token);
                message =
                    $"Consumed event from topic {topic} with key {cr?.Message?.Key ?? "NONE"} and value {cr?.Message?.Value ?? "NONE"}";
                Console.WriteLine(message);
            }
        }
        catch (OperationCanceledException)
        {
            // Ctrl-C was pressed.
        }
        finally
        {
            consumer.Close();
        }

        return message;
    }
}