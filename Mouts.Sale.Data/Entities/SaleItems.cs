using Mouts.Sale.Data.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouts.Sale.Data.Entities
{
    public class SaleItems
    {
        public Guid SaleItemsId { get; set; }

        public Guid SaleId { get; set; }

        public Guid ProductExternalId { get; set; }

        public int Amount { get; set; }

        public virtual ProductExternal Product { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
