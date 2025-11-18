using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using RabbitMQ.Client.Events;

namespace backApiv2.Services
{
    public class QueueHostedService : BackgroundService
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IDistributedCache _cache;
        private IConnection _connection;
        private IChannel _channel;

        public QueueHostedService(IConnectionFactory connectionFactory, IDistributedCache cache)
        {
            _connectionFactory = connectionFactory;
            _cache = cache;
        }

        public override async Task<Task> StartAsync(CancellationToken cancellationToken)
        {
            _connection = await _connectionFactory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();
            await _channel.QueueDeclareAsync(queue: "processing_queue",durable: false,exclusive: false,autoDelete: false,arguments: null);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var cacheKey = $"processed_message:{Guid.NewGuid()}";

                // Simulate work
                await Task.Delay(2000);

                await _cache.SetStringAsync(cacheKey, message, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });

                await _channel.BasicAckAsync(ea.DeliveryTag, false);
            };

            await _channel.BasicConsumeAsync(queue: "processing_queue", autoAck: false, consumer: consumer);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _channel?.CloseAsync();
            _connection?.CloseAsync();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
