using System;
using System.Text;
using Newtonsoft.Json;
using OnlineStoreWorker.Models;
using OnlineStoreWorker.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OnlineStoreWorker.Messaging
{
    public class OnlineStoreMq 
    {
        CustomerRepository _customerRepository;

        public OnlineStoreMq()
        {
            _customerRepository = new CustomerRepository();
        }

        public void ConsumeMessage()
        {
            try
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

                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                    channel.QueueBind(queue: "store_queue", exchange: "StoreExch", routingKey: "store_route");


                    var consumer = new EventingBasicConsumer(channel);

                    BasicGetResult result = channel.BasicGet("store_queue", true);
                    if (result != null)
                    {
                        string message = Encoding.UTF8.GetString(result.Body);
                        var customer = JsonConvert.DeserializeObject<Customer>(message);
                        _customerRepository.Insert(customer);
                    }

                    channel.BasicConsume(queue: "store_queue", autoAck: false, consumer: consumer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ConsumeMessage: " + ex.Message);
            }
        }
    }
}
