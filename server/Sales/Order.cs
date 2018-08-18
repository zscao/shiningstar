using Infrastructure;
using NServiceBus;
using Sales.Contracts;
using Sales.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales
{
    /// <summary>
    /// the order aggregate
    /// </summary>
    public class Order: IEventSourced
    {
        private IEnumerable<OrderItem> _items;
        private OrderStatus _status;

        public Guid Id { get; }

        public IEnumerable<IEvent> Events
        {
            get
            {
                return _events;
            }
        }

        private List<IEvent> _events;

        public Order(Guid orderId, IEnumerable<OrderItem> items)
        {
            Id = orderId;
            _items = items;
            _status = OrderStatus.Pending;
            _events = new List<IEvent>()
            {
                new OrderPlaced
                {
                    OrderId = orderId,
                    Items = items
                }
            };
        }

        public void ConfirmOrder()
        {
            _status = OrderStatus.Confirmed;

            _events.Add(new OrderConfirmed
            {
                OrderId = this.Id
            });
        }

        public void CancelOrder()
        {
            _status = OrderStatus.Cancelled;

            _events.Add(new OrderCanceled
            {
                OrderId = this.Id
            });
        }
    }
}
