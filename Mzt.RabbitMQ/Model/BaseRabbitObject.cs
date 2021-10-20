using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.RabbitMQ
{
    public class BaseRabbitObject
    {
        public string Message { get; set; }
        public ulong DeliveryTag { get; set; }
    }
}
