using System;
using System.Collections.Generic;
using System.Text;

namespace MicroControllers.Domain.ViewModel
{
    //This type must be the same for everything, once the RabbitMq recognise using the namespace.
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}
