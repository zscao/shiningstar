using System;

namespace Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //RabbitMQHelper.CreateQueuesForEndpoint(
            //    uri: "amqp://guest:guest@localhost:5672/shiningstar",
            //    endpointName: "ClientUI",
            //    durableMessages: true,
            //    createExchanges: true);

            //RabbitMQHelper.CreateQueuesForEndpoint(
            //    uri: "amqp://guest:guest@localhost:5672/shiningstar",
            //    endpointName: "Sales",
            //    durableMessages: true,
            //    createExchanges: true);

            //RabbitMQHelper.CreateQueuesForEndpoint(
            //    uri: "amqp://guest:guest@localhost:5672/shiningstar",
            //    endpointName: "Billing",
            //    durableMessages: true,
            //    createExchanges: true);


            Console.WriteLine("Done. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
