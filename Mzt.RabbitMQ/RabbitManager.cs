using Mzt.Serialization;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mzt.RabbitMQ
{
    public class RabbitManager<T> : IDisposable where T : BaseRabbitObject, new()
    {
        ConnectionFactory _factory;
        IConnection _connection;
        IModel _channel;
        string _exchangeName;
        public RabbitManager()
        {
            _connection = Factory.CreateConnection();
            _connection.ConnectionShutdown += new EventHandler<ShutdownEventArgs>(ConnectionShutdown);
            _channel = _connection.CreateModel();
        }

        public ConnectionFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    var hostName =
                    _factory = new ConnectionFactory
                    {
                        HostName = "192.168.201.91",
                        UserName = "manager",
                        Password = "E[3@mz2"
                    };
                }
                return _factory;
            }
            set
            {
                _factory = value;
            }
        }

        public void Push(string message, string exchangeName = "", int delay = 0)
        {
            var obj = new BaseRabbitObject();
            obj.Message = message;
            Push(obj, exchangeName, delay);
        }

        public void Push(BaseRabbitObject obj, string exchangeName = "", int delay = 0)
        {
            var message = Serializer.ToJSON(obj);
            var bytes = Encoding.UTF8.GetBytes(message);
            Push(bytes, exchangeName, delay);
        }

        private void Push(byte[] message,
            string exchangeName = "", int delay = 0)
        {
            Bind(exchangeName);
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;
            if (delay != 0)
            {
                if (properties.Headers == null)
                    properties.Headers = new Dictionary<string, object>();
                properties.Headers.Add("x-delay", delay);
            }
            _channel.BasicPublish(exchangeName, "", properties, message);
        }

        public void CheckIn(EventHandler<T> handler, string exchangeName = "")
        {
            _exchangeName = exchangeName;
            Handle(handler, exchangeName, false);
        }

        public void CheckOut(ulong messageId)
        {
            if (_connection != null && _channel != null && _channel.IsOpen)
                _channel.BasicAck(messageId, false);
            else
                Console.WriteLine($"Something went wrong {messageId} is unAcked");
        }

        public void Pop(EventHandler<T> handler, string exchangeName = "")
        {
            Handle(handler, exchangeName, true);
        }

        private void ConnectionShutdown(object sender, ShutdownEventArgs ea)
        {
            Console.WriteLine("ConnectionShutdown");
        }

        private void Handle(EventHandler<T> outHandler, string exchangeName, bool noAck)
        {
            Bind(exchangeName);
            var consumer = new EventingBasicConsumer(_channel);
            var inHandler = new EventHandler<BasicDeliverEventArgs>((model, ea) =>
            {
                outHandler(model, ea.GetBaseObject<T>());
            });
            consumer.Received += inHandler;
            _channel.BasicConsume(exchangeName, noAck, "", consumer);
            Thread.Sleep(100);
        }

        private void Bind(string exchangeName)
        {
            if (string.IsNullOrEmpty(exchangeName))
                exchangeName = "defaultExchange";
            var args = new Dictionary<string, object>();
            args.Add("x-delayed-type", "direct");
            _channel.ExchangeDeclare(exchangeName, "x-delayed-message", true, true, args);
            var queue = _channel.QueueDeclare(exchangeName,
                durable: true, //say if server will shutdown then queue be safe
                exclusive: false,
                autoDelete: false,
                arguments: null);
            _channel.QueueBind(queue.QueueName, exchangeName, "");
        }

        public void Dispose()
        {
            if (_channel != null)
            {
                _channel.Dispose();
            }
            if (_connection != null)
                _connection.Dispose();
        }

    }
}
