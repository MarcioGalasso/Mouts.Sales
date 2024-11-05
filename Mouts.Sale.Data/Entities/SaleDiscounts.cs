
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
