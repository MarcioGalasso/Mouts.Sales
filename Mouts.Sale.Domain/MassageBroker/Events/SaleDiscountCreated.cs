﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouts.Sale.Domain.MassageBroker.Events
{
    public class SaleDiscountCreated
    {
        public decimal Value { get; set; }
        public string Description { get; set; }
    }
}
