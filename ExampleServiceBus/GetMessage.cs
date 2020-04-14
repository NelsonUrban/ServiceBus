using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using System;
using System.Threading.Tasks;

namespace ExampleServiceBus
{
    public class GetMessage
    {
        static IMessageReceiver messageReceiver;
        private const string ServiceBusConnectionString ="";
        private const string QueueName = "";
        public async Task ReceiveMessages()
        {
            try
            {
                messageReceiver =
                    new MessageReceiver(ServiceBusConnectionString, QueueName);
                while (messageReceiver.OwnsConnection)
                {

                     Message message = await messageReceiver.ReceiveAsync();

                    Console.WriteLine($"Received message: {message.Body}");

                    await messageReceiver.CloseAsync();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
            }

            await Task.Delay(10);
        }
    }
}


