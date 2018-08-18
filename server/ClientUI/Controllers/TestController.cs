using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sales.Contracts.Commands;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

namespace ClientUI.Controllers
{
    public class TestController : Controller
    {
        private IMessageSession _messageSession;
        static int messagesSent = 0;


        public TestController(IMessageSession messageSession)
        {
            _messageSession = messageSession;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> PlaceOrder()
        {
            var orderId = Guid.NewGuid();

            var command = new PlaceOrder { OrderId = orderId };

            // Send the command
            await _messageSession.Send(command)
                .ConfigureAwait(false);

            dynamic model = new ExpandoObject();
            model.OrderId = orderId.ToString();
            model.MessagesSent = Interlocked.Increment(ref messagesSent);

            return View(model);
        }
    }
}