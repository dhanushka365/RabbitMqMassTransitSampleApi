using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//namespace would be get as the exchange name by default
namespace RabbitMqMassTransitSampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;
        
        public ValueController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            //this passing object value also get into the exchange name
            await _publishEndpoint.Publish<ValueCreated>(new { Value = value });
            return Ok();
        }
    }
}
