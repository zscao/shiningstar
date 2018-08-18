using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Contracts.Events
{
    public class OrderCanceled: IEvent
    {
        public Guid OrderId { get; set; }
    }
}
