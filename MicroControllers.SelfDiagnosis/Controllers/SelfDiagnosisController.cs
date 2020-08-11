using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MicroControllers.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroControllers.SelfDiagnosis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfDiagnosisController : ControllerBase
    {
        private readonly IBusControl _bus;

        public SelfDiagnosisController(IBusControl bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            Uri uri = new Uri("rabbitmq://localhost/selfdiagnosis-queue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(message);

            return Ok("Message has been forwardedby Self Diagnosis.");
        }

    }
}
