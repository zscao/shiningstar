﻿using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Contracts.Commands
{
    public class CancelOrder: ICommand
    {
        public Guid OrderId { get; set; }
    }
}
