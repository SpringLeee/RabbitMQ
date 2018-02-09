using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customs
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
                        BasicGetResult res = im.BasicGet("Logs", true);
                       
                        if (res != null)
                        {

                            Console.WriteLine("receive :" + UTF8Encoding.UTF8.GetString(res.Body));
                        }
                    }

                }
            }


        }
    }
}
