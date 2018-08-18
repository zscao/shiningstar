using Infrastructure;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Sales
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Sales Service";
            Console.WriteLine("Sales service is running...");
            
            var endpointConfiguration = new EndpointConfiguration("Sales");


            endpointConfiguration.RegisterComponents(
                registration: components =>
                {
                    components.ConfigureComponent<IEventSourcedRepository>(
                        componentFactory: builder =>
                        {
                            return new MongoDbEventSourcedRepository(null, null);
                        }, 
                        dependencyLifecycle: DependencyLifecycle.InstancePerUnitOfWork);
                }
            );

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString("Host=localhost;VirtualHost=shiningstar");
            transport.UsePublisherConfirms(true);
            transport.UseConventionalRoutingTopology();

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
