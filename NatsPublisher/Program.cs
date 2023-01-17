using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Options;
using NATS.Client;
using System;
using System.Text;
using System.Threading;

namespace Publisher
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ConnectionFactory cf = new ConnectionFactory();
            IConnection c = cf.CreateConnection();

            var index = 1;
            c.Publish("nats.poc.*", Encoding.UTF8.GetBytes("teste"));
            while (true)
            {
                var message = $"{index++} : Hello World!";
                Console.WriteLine($"{DateTime.Now:F} - Send: {message}");

                //Publicação
                c.Publish("nats.poc.test", Encoding.UTF8.GetBytes(message));


                Thread.Sleep(1000);
            }
        }
    }
}