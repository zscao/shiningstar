using Sales.Contracts.Events;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Sales.EventHandlers
{
    public class OrderEventsHandler : IHandleMessages<OrderPlaced>
    {
        static ILog log = LogManager.GetLogger<OrderEventsHandler>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            log.Info($"Sales has received OrderPlaced, OrderId = {message.OrderId}");
            return Task.CompletedTask;
        }
    }
}
