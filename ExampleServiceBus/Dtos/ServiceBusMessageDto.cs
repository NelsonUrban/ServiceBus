using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleServiceBus.Dtos
{
    public class ServiceBusMessageDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
