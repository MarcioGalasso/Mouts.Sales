
using Mouts.Sale.Domain.Entities;
namespace Mouts.Sale.Domain.Interface
{
    public interface ISaleService : IBaseService
    {
        Task<Entities.Sale> GetAsync(Guid saleId);
        Task<Entities.Sale> CancelSaleAsync(Guid saleId);
        Task<Domain.Entities.Sale> CreateAsync(Domain.Entities.Sale sale);
        Task<bool> DeleteAsync(Guid saleId);
    }
}
