using NServiceBus;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class MessageHandlerContextExtensions
    {
        public static async Task PublishEvents(this IMessageHandlerContext context, IEventSourced source)
        {
            if (source?.Events?.Count() > 0)
            {
                foreach (var e in source.Events)
                    await context.Publish(e);
            }
        }
    }
}
