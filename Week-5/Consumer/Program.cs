using Confluent.Kafka;

Console.WriteLine("🟢 Kafka Chat Consumer (listening to 'chat-topic')");

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "chat-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe("chat-topic");

try
{
    while (true)
    {
        var cr = consumer.Consume();
        Console.WriteLine($"👤 {cr.Message.Value}");
    }
}
catch (OperationCanceledException)
{
    consumer.Close();
}
