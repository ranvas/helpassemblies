using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.RabbitMQ
{
    public class CatchRabbitObject : BaseRabbitObject
    {
        public int Retry { get; set; }
        public string LastErrorText { get; set; }
    }
}
