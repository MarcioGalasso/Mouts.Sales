using Mouts.Sale.Domain.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouts.Sale.Data.Entities
{
    public class SaleDiscounts
    {
        public Guid SaleDiscountsId { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }

        public Guid SaleId { get; set; }

        public virtual Sale Sale { get; set; }


    }
}
