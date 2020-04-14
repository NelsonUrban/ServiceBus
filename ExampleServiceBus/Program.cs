using Microsoft.Azure.ServiceBus;
using System;
using System.Threading.Tasks;

namespace ExampleServiceBus
{
    class Program
    {
        static ITopicClient topicClient = null;
        static void Main(string[] args)
        {
            var getMessage = new GetMessage();
            MainAsync(topicClient).GetAwaiter().GetResult();

            Console.WriteLine("Recibiendo Mensajes");

            getMessage.ReceiveMessages().GetAwaiter().GetResult();
        }
        static async Task MainAsync(ITopicClient topicClient)
        {
            const string ServiceBusConnectionString = "";
            const string TopicName = "";

            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            var userMessage = new SendUserMessage();
            await userMessage.SendMessage(topicClient);

            Console.ReadKey();

            await topicClient.CloseAsync();

        }


    }

}



