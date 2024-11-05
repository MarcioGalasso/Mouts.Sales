using Mouts.Sale.Data.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouts.Sale.Domain.Entities
{
    public class SaleItems
    {


        public Guid ProductExternalId { get; set; }

        public int Amount { get; set; }
    }
}
