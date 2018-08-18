using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Contracts.Commands
{
    public class PlaceOrder : ICommand
    {
        public Guid OrderId { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}
