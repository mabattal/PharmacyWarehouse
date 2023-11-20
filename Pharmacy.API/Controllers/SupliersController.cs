using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Filters;
using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;
using Pharmacy.Core.Services;

namespace Pharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupliersController : CustomBaseController
    {
        private readonly ISuplierService _suplierService;
        private readonly IMapper _mapper;

        public SupliersController(ISuplierService suplierService, IMapper mapper)
        {
            _suplierService = suplierService;
            _mapper = mapper;
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
            var suplier = await _suplierService.GetAllAsync();
            var suplierDto = _mapper.Map<List<SuplierDto>>(suplier).ToList();
            return CreateActionResult(CustomResponseDto<List<SuplierDto>>.Successs(200, suplierDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Suplier>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var suplier = await _suplierService.GetByIdAsync(id);
            var suplierDto = _mapper.Map<SuplierDto>(suplier);
            return CreateActionResult(CustomResponseDto<SuplierDto>.Successs(200, suplierDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SuplierDto suplierDto)
        {
            var suplier = await _suplierService.AddAsync(_mapper.Map<Suplier>(suplierDto));
            var SuplierDto = _mapper.Map<SuplierDto>(suplier);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(201));
        }

        [HttpPut]
        public async Task<IActionResult> Update(SuplierDto suplierDto)
        {
            await _suplierService.UpdateAsync(_mapper.Map<Suplier>(suplierDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(201));
        }

        [ServiceFilter(typeof(NotFoundFilter<Suplier>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var suplier = await _suplierService.GetByIdAsync(id);
            await _suplierService.RemoveAsyn(suplier);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(204));
        }
    }
}
