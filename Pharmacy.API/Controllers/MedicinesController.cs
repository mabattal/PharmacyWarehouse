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
    public class MedicinesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IMedicineService _medicineService;

        public MedicinesController(IMapper mapper, IMedicineService medicineService)
        {
            _mapper = mapper;
            _medicineService = medicineService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMedicinesWithSuplier()
        {
            return CreateActionResult(await _medicineService.GetMedicineWithSuplier());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var medicines = await _medicineService.GetAllAsync();
            var medicinesDtos = _mapper.Map<List<MedicineDto>>(medicines.ToList());
            return CreateActionResult(CustomResponseDto<List<MedicineDto>>.Successs(200, medicinesDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Medicine>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medicine = await _medicineService.GetByIdAsync(id);
            var medicinesDto = _mapper.Map<MedicineDto>(medicine);
            return CreateActionResult(CustomResponseDto<MedicineDto>.Successs(200, medicinesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MedicineDto medicineDto)
        {
            var medicine = await _medicineService.AddAsync(_mapper.Map<Medicine>(medicineDto));
            var medicinesDto = _mapper.Map<MedicineDto>(medicine);
            return CreateActionResult(CustomResponseDto<MedicineDto>.Successs(201, medicinesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MedicineUpdateDto medicineUpdateDto)
        {
            await _medicineService.UpdateAsync(_mapper.Map<Medicine>(medicineUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Medicine>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var medicine = await _medicineService.GetByIdAsync(id);
            await _medicineService.RemoveAsyn(medicine);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(204));
        }
    }
}
