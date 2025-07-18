using Confluent.Kafka;

Console.WriteLine("🔵 Kafka Chat Producer (type 'exit' to quit)");
var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

using var producer = new ProducerBuilder<Null, string>(config).Build();

while (true)
{
    Console.Write("You: ");
    var message = Console.ReadLine();

    if (message?.ToLower() == "exit")
        break;

    var result = await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });

    Console.WriteLine($"✅ Sent to partition {result.Partition}, offset {result.Offset}");
}
