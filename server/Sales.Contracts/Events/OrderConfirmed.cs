using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Contracts.Events
{
    public class OrderConfirmed: IEvent
    {
        public Guid OrderId { get; set; }
    }
}
