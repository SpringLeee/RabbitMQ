using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {

            ConnectionFactory factory = new ConnectionFactory { HostName = "localhost" };
            using (IConnection conn = factory.CreateConnection())
            {
                using (IModel im = conn.CreateModel())
                {
                    im.ExchangeDeclare("rabbitmq_route", ExchangeType.Direct);
                    im.QueueDeclare("rabbitmq_query", true, false, false, null);
                    im.QueueBind("rabbitmq_query", "rabbitmq_route", ExchangeType.Direct, null);

                    Parallel.For(1,1000, i=> {

                        byte[] message = Encoding.UTF8.GetBytes("Hello --  " + i);
                        im.BasicPublish("rabbitmq_route", ExchangeType.Direct, null, message);
                        Console.WriteLine("send -- " + i);

                    });
                    
                    Console.ReadKey();
                }
            }

        }
    }
}
