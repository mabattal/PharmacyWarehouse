using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Filters;
using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;
using Pharmacy.Core.Services;

namespace Pharmacy.API.Controllers
{
    public class SupliersController : CustomBaseController
    {
        private readonly ISuplierService _suplierService;

        public SupliersController(ISuplierService suplierService)
        {
            _suplierService = suplierService;
        }

        [ServiceFilter(typeof(NotFoundFilter<Suplier>))]
        [HttpGet("[action]/{suplierId}")]
        public async Task<IActionResult> GetSingleSuplierByIdWithMedicines(int suplierId)
        {
            return CreateActionResult(await _suplierService.GetSingleSuplierByIdWithMedicineAsync(suplierId));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult(await _suplierService.GetAllAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Suplier>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _suplierService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SuplierCreateDto suplierDto)
        {
            return CreateActionResult(await _suplierService.AddAsync(suplierDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(SuplierUpdateDto suplierDto)
        {
            return CreateActionResult(await _suplierService.UpdateAsync(suplierDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Suplier>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _suplierService.RemoveAsync(id));
        }
    }
}
