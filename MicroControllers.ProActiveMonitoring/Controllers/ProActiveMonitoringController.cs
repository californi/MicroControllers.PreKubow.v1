using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MicroControllers.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroControllers.ProActiveMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProActiveMonitoringController : ControllerBase
    {
        private readonly IBusControl _bus;

        public ProActiveMonitoringController(IBusControl bus) {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            Uri uri = new Uri("rabbitmq://localhost/proactivemonitoring-queue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(message);

            return Ok("Message has been forwarded by Pro Active Monitoring.");
        }

    }
}
