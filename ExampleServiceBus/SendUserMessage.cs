using ExampleServiceBus.Dtos;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExampleServiceBus
{
    public class SendUserMessage
    {
        public async Task SendMessage(ITopicClient topicClient)
        {
            var getDummyDataForUser = new GetDummyDataForUser();
            List<UserDto> users = getDummyDataForUser.GetDataForUser();

            var serializeUser = JsonConvert.SerializeObject(users);

            string messageType = "po";
            string Status = "new";

            string messageId = Guid.NewGuid().ToString();

            var message = new ServiceBusMessageDto
            {
                Id = messageId,
                Type = messageType,
                Content = serializeUser
            };
            var serializeBody = JsonConvert.SerializeObject(message);

            var busMessage = new Message(Encoding.UTF8.GetBytes(serializeBody));
            busMessage.UserProperties.Add("Type", messageType);
            busMessage.UserProperties.Add("status", Status);
            busMessage.SessionId = "po";
            busMessage.MessageId = messageId;
            await topicClient.SendAsync(busMessage);         
            Console.WriteLine("Message sent");
        }

    }
}
