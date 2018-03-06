using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public static  class Delivery
    {

        public static string HostName = "localhost";
        public static int Port = 5672;
        public static string UserName = "david";
        public static string Password = "D@v1d";
        public static IModel Im = new ConnectionFactory {
            HostName = HostName,
            Port = Port,
            UserName = UserName,
            Password = Password
        }.CreateConnection().CreateModel();


        public static void Send(string info)
        {
            Im.ExchangeDeclare("MyExchange", ExchangeType.Topic,true,false);
            Im.QueueDeclare("Logs", true, false, false, null);
            Im.QueueBind("Logs", "MyExchange", ExchangeType.Topic, null);

            byte[] message = Encoding.UTF8.GetBytes(info);
            Im.BasicPublish("MyExchange", ExchangeType.Topic, null,message);
        }
     

    }
}
