using Confluent.Kafka;

namespace SpendingApp.Messages;

public class Producer
{
    public void Bruh()
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "bootstrap.servers=kafka.application.svc.cluster.local:9092"
        };
        /*var a = new ProducerConfig
        {
            BootstrapServers = "pkc-6ojv2.us-west4.gcp.confluent.cloud:9092",
            SaslMechanism = SaslMechanism.Plain,
            SaslUsername = "FPOTEB6VQ6UXGTWW",
            SaslPassword = "UQX5K8CHU+4FaWzC87zhYRivvrCfbqvvy46wftOpFNmXBnDprh+Kum/nPVpb5lmr",
        };
        var config = new List<KeyValuePair<string, string>>
        {
            new("bootstrap.servers", "pkc-6ojv2.us-west4.gcp.confluent.cloud:9092"),
            new("sasl.mechanisms", "PLAIN"),
            new("sasl.username", "CICXHSJ3RCR6UWVL"),
            new("sasl.password", "NssGPawMJ5btPyIlzV1k6Eaf5mV1Lq0b0yJ7mSxXyduFrsNwx/aTTN4XCZ++QXbs")
        };*/

        const string topic = "firstTopic";

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