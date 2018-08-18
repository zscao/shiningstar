using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Contracts.Events
{
    public class OrderPlaced : IEvent
    {
        public Guid OrderId { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}
