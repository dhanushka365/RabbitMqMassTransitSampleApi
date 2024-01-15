using MassTransit;
using RabbitMqMassTransitSampleApi.Controllers;

namespace RabbitMqMassTransitSampleApi.Consumer
{
    public class EventConsumer:IConsumer<ValueCreated>
    {
        ILogger<EventConsumer> _logger; 

        public EventConsumer(ILogger<EventConsumer> logger)
        {
            _logger = logger;
        }


        public async Task Consume(ConsumeContext<ValueCreated> context)
        {
            _logger.LogInformation($"Value created: {context.Message.Value}");
        }
    }
}
