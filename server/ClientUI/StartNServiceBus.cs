using Sales.Contracts.Commands;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace ClientUI
{
    public class StartNServiceBus
    {
        public static async Task<IEndpointInstance> StartEndpoint()
        {
            try
            {
                var endpointConfiguration = new EndpointConfiguration("ClientUI");
                var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
                transport.ConnectionString("Host=localhost;VirtualHost=shiningstar");
                transport.UsePublisherConfirms(true);
                transport.UseConventionalRoutingTopology();

                var routing = transport.Routing();

                routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

                return await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
