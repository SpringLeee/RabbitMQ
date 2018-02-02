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
                        BasicGetResult res = im.BasicGet("rabbitmq_query", true);
                       
                        if (res != null)
                        {

                                FileStream fs = new FileStream(@"E://log.txt", FileMode.Append);

                                StreamWriter sw = new StreamWriter(fs);
                                //开始写入
                                sw.Write(DateTime.Now.ToString() + "      " + UTF8Encoding.UTF8.GetString(res.Body) + "\r\n");
                                //清空缓冲区
                                sw.Flush();
                                //关闭流
                                sw.Close();
                                fs.Close();


                            Console.WriteLine("receiver:" + UTF8Encoding.UTF8.GetString(res.Body));
                        }

                    }

                }
            }


        }
    }
}
