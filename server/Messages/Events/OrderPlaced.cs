using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Events
{
    public class OrderPlaced: IEvent
    {
        public Guid OrderId { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}
