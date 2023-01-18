using Confluent.Kafka;

namespace IncomeService.Messages;

public class Consumer
{
    public void Bruh()
    {
        const string topic = "firstTopic";

        var cts = new CancellationTokenSource();
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
        using var consumer = new ConsumerBuilder<string, string>(config).Build();
        consumer.Subscribe(topic);
        try
        {
            while (true)
            {
                var cr = consumer.Consume(cts.Token);
                Console.WriteLine(
                    $"Consumed event from topic {topic} with key {cr.Message.Key} and value {cr.Message.Value}");
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
    }
}