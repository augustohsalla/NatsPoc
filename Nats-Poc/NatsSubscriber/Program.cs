using Microsoft.AspNetCore.Connections;
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

            //Subscrição
            EventHandler<MsgHandlerEventArgs> h = (sender, args) =>
            {
                Console.WriteLine($"{DateTime.Now:F} - Received: {args.Message}");
            };

            IAsyncSubscription asyncSub = c.SubscribeAsync("nats.poc.*");
            ISyncSubscription syncSub = c.SubscribeSync("nats.poc.test");

            asyncSub.MessageHandler += h;
            asyncSub.Start();

            Console.ReadLine();

            try
            {
                Msg m = syncSub.NextMessage(1000);
                string text = Encoding.UTF8.GetString(m.Data);
                Console.WriteLine($"Sync subscription received the message '{text}' from subject '{m.Subject}'");
                m = syncSub.NextMessage(100);
            }
            catch (NATSTimeoutException)
            {
                Console.WriteLine($"Sync subscription no messages currently available");
            }

            asyncSub.Unsubscribe();
            c.Drain();
            c.Close();
        }
    }
}