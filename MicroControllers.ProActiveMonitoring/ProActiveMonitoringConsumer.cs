using MassTransit;
using MicroControllers.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroControllers.ProActiveMonitoring
{
    public class ProActiveMonitoringConsumer : IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            var data = context.Message;
            await Console.Out.WriteLineAsync(data.ToString());
            // message received.
        }
    }
}
