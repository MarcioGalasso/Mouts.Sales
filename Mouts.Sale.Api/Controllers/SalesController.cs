using Microsoft.AspNetCore.Mvc;
using Mouts.Sale.Domain.Interface;

namespace Mouts.Sale.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {

        private readonly ILogger<SalesController> _logger;
        private readonly ISaleService _saleService;

        public SalesController(ILogger<SalesController> logger, ISaleService saleService)
        {
            _logger = logger;
            _saleService = saleService;
        }

        [HttpGet("{salesId}")]
        public async Task<IActionResult> GetAsync(Guid salesId)
        {
            var sale = await _saleService.GetAsync(salesId);
            if (sale != default)
                return Ok(sale);

            return NoContent();
        }

        [HttpDelete("{salesId}")]
        public async Task<IActionResult> DeleteAsync(Guid salesId)
        =>  Ok(await _saleService.DeleteAsync(salesId));

        [HttpPost("")]
        public async Task<IActionResult> CreatedAsync(Domain.Entities.Sale sale)
        => Ok(await _saleService.CreateAsync(sale));


        [HttpPut("{saleId}/cancel")]
        public async Task<IActionResult> UpdateAsync(Guid saleId)
       => Ok(await _saleService.CancelSaleAsync(saleId));
    }
}