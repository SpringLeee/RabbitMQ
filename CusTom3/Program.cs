using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CusTom3
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
                    while (true)
                    {
                        BasicGetResult res = im.BasicGet("rabbitmq_query", true);
                        if (res != null)
                        {
                            Console.WriteLine("receiver:" + UTF8Encoding.UTF8.GetString(res.Body));
                        }

                    }

                }
            }



        }
    }
}
