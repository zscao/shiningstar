using NServiceBus;
using System;
using System.Collections.Generic;

namespace Messages.Commands
{
    public class PlaceOrder: ICommand
    {
        public Guid OrderId { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}
