using Mzt.Serialization;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.RabbitMQ
{
    public static class DeliverEventArgsExtensions
    {
        internal static T GetBaseObject<T>(this BasicDeliverEventArgs args) where T: BaseRabbitObject, new()
        {
            var body = args.Body;
            var message = Encoding.UTF8.GetString(body);
            try
            {
                var obj = Serializer.Deserialize<T>(message);
                obj.DeliveryTag = args.DeliveryTag;
                return obj;
            }
            catch (Exception e)
            {
                return new T { Message = message, DeliveryTag = args.DeliveryTag };
            }
        }
    }
}
