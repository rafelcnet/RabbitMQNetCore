using System;
using System.Text;
using Newtonsoft.Json;
using OnlineStoreWebApi.Models;
using RabbitMQ.Client;

namespace OnlineStoreWebApi.Messaging
{
    public class OnlineStoreMq
    {
        public OnlineStoreMq()
        {
        }

        public void SendMessage(Customer customer)
        {
            var onlineStoreMqUserName = "rcotest"; // Environment.GetEnvironmentVariable("ONLINE_STORE_MQ_USERNAME");
            var onlineStoreMqPassword = "Test2019"; // Environment.GetEnvironmentVariable("ONLINE_STORE_MQ_PASSWORD");
            var onlineStoreMqServer = "192.168.0.102"; // Environment.GetEnvironmentVariable("ONLINE_STORE_MQ_SERVER");

            var factory = new ConnectionFactory()
            { HostName = onlineStoreMqServer, UserName = onlineStoreMqUserName, Password = onlineStoreMqPassword, Port = 5672 };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                channel.ExchangeDeclare("StoreExch", "direct");

                channel.QueueDeclare(queue: "store_queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                channel.QueueBind(queue: "store_queue", exchange: "StoreExch", routingKey: "store_route");

                string customerData = JsonConvert.SerializeObject(customer);
                var body = Encoding.UTF8.GetBytes(customerData);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "StoreExch",
                                     routingKey: "store_route",
                                     basicProperties: properties,
                                     body: body);
            }

        }
    }
}
