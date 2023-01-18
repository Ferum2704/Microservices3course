using Confluent.Kafka;

namespace SpendingApp.Messages;

public class Producer
{
    public void Bruh(string topic)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "bootstrap.servers=kafka.application.svc.cluster.local:9092"
        };

        using var producer = new ProducerBuilder<string, string>(config).Build();
        var numProduced = 0;
        const int numMessages = 10;
        for (var i = 0; i < numMessages; ++i)
        {

            producer.Produce(topic, new Message<string, string> {Key = "spending message", Value = "received"},
                deliveryReport =>
                {
                    if (deliveryReport.Error.Code != ErrorCode.NoError)
                    {
                        Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                    }
                    else
                    {
                        Console.WriteLine($"Produced event to topic {topic}: key = spending message value = received");
                        numProduced += 1;
                    }
                });
        }

        producer.Flush(TimeSpan.FromSeconds(10));
        Console.WriteLine($"{numProduced} messages were produced to topic {topic}");
    }
}