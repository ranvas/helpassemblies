using System;

namespace Test_NetStandart
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var rabbit = new RabbitManager<CatchRabbitObject>())
            {
                rabbit.Push(new CatchRabbitObject { Message = "test object ", Retry = 0, LastErrorText = "was no errors" }, "AlphaBankPayment");
            }

            Console.ReadLine();
        }
    }
}
