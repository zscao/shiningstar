using NServiceBus;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IEventSourcedRepository
    {
        Task Save(IEventSourced source);
    }
}
