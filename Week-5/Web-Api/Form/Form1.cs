using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafkaChatFormApp
{
    public partial class Form1 : Form
    {
        private readonly string topic = "chat-topic";
        private readonly string bootstrapServers = "localhost:9092";
        private IProducer<Null, string>? producer;
        private CancellationTokenSource? cts;

        public Form1()
        {
            InitializeComponent();
            InitializeKafkaProducer();
            StartKafkaConsumer();
        }

        private void InitializeKafkaProducer()
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        private void StartKafkaConsumer()
        {
            Task.Run(() =>
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = bootstrapServers,
                    GroupId = "chat-group",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                consumer.Subscribe(topic);
                cts = new CancellationTokenSource();

                try
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        var cr = consumer.Consume(cts.Token);
                        Invoke((MethodInvoker)(() =>
                        {
                            lstChat.Items.Add($"👤 {cr.Message.Value}");
                        }));
                    }
                }
                catch (OperationCanceledException) { }
                finally
                {
                    consumer.Close();
                }
            });
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message) && producer != null)
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
                lstChat.Items.Add($"🟢 You: {message}");
                txtMessage.Clear();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            cts?.Cancel();
            base.OnFormClosing(e);
        }
    }
}
