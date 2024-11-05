using AutoMapper;
using Mouts.Sale.Data.Repository.Interface;
using Mouts.Sale.Domain.Interface;

namespace Mouts.Sale.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<Entities.Sale> GetAsync(Guid saleId)
        {
            var sale = await _saleRepository.GetAsync(saleId);

            if (sale == default)
                return default;

            return _mapper.Map<Entities.Sale>(sale);

        }

        public  Task<bool> DeleteAsync(Guid saleId)
        => _saleRepository.RemoveByIdAsync(saleId);

        public async  Task<Entities.Sale> CancelSaleAsync(Guid saleId)
        {
            var sale = await _saleRepository.GetAsync(saleId);
            sale.Status = Data.Enum.SaleStatusEnum.Canceled;

            await _saleRepository.UpdateAsync(sale);
            return _mapper.Map<Entities.Sale>(sale);
        }

        public async Task<Domain.Entities.Sale> CreateAsync(Domain.Entities.Sale sale)
        {
            var saleEntites =  _mapper.Map<Data.Entities.Sale>(sale);
            sale.Status = Data.Enum.SaleStatusEnum.Canceled;
            await _saleRepository.AddAsync(saleEntites);
            return _mapper.Map<Entities.Sale>(sale);
        }

    }
}
