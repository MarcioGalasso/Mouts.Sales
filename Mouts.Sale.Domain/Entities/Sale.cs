using Mouts.Sale.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouts.Sale.Domain.Entities
{
    public class Sale
    {
        public Guid SalesId { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EnterpriseId { get; set; }
        public decimal Value { get; set; }

        public List<Entities.SaleDiscount> Discont { get; set; }

        public List<SaleItems> Items { get; set; }
        public SaleStatusEnum Status { get; set; }
    }
}
