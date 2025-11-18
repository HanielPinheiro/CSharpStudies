using System.Text.Json;
using System.Text;
using RabbitMQ.Client;

namespace backApiv2.Services
{
    public class QueueService
    {
        private readonly IConnectionFactory _connectionFactory;

        public QueueService(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task PublishMessageAsync<T>(string queueName, T message)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var jsonMessage = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queueName, body: body);
        }
    }
}
