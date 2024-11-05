using Mouts.Sale.Data.Enum;
using Mouts.Sale.Data.External;

namespace Mouts.Sale.Data.Entities
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public Guid EnterpriseId { get; set; }
        public Guid CustomerExternalId { get; set; }
        public virtual CustomerExternal Customer { get; set; }
        public virtual EnterpriseExternal Enterprise { get; set; }
        public virtual List<SaleItems> Items { get; set; }
        public virtual List<SaleDiscounts> Discounts { get; set; }

        public SaleStatusEnum Status { get; set; }

    }
}
