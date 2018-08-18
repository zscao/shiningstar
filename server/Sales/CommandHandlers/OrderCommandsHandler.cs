using Infrastructure;
using NServiceBus;
using NServiceBus.Logging;
using Sales.Contracts.Commands;
using Sales.Contracts.Events;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.CommandHandlers
{
    public class OrderCommandsHandler :
            IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<OrderCommandsHandler>();

        IEventSourcedRepository _eventSourcedRepository;


        public OrderCommandsHandler(IEventSourcedRepository repository)
        {
            _eventSourcedRepository = repository;
        }

        public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            log.Info($"Received command PlaceOrder, OrderId = {message.OrderId}");

            var order = new Order(message.OrderId, message.Items);


            await _eventSourcedRepository.Save(order);
            await context.PublishEvents(order);
        }
    }
}
