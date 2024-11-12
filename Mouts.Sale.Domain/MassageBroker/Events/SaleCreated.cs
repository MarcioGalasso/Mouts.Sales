using Mouts.Sale.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouts.Sale.Domain.MassageBroker.Events
{
    public class SaleCreated
    {
        public Guid SalesId { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EnterpriseId { get; set; }
        public decimal Value { get; set; }

        public List<SaleDiscountCreated> Discont { get; set; }

        public List<SaleItemsCreated> Items { get; set; }
        public SaleStatusEnum Status { get; set; }
    }
}
