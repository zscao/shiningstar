using NServiceBus;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public interface IEventSourced
    {
        Guid Id { get; }

        IEnumerable<IEvent> Events { get; }

    }
}
