using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IService<Medicine> _service;

        public MedicinesController(IMapper mapper, IService<Medicine> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var medicines = await _service.GetAllAsync();
            var medicinesDtos = _mapper.Map<List<MedicineDto>>(medicines.ToList());
            return CreateActionResult(CustomResponseDto<List<MedicineDto>>.Successs(200, medicinesDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medicine = await _service.GetByIdAsync(id);
            var medicinesDto = _mapper.Map<MedicineDto>(medicine);
            return CreateActionResult(CustomResponseDto<MedicineDto>.Successs(200, medicinesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MedicineDto medicineDto)
        {
            var medicine = await _service.AddAsync(_mapper.Map<Medicine>(medicineDto));
            var medicinesDto = _mapper.Map<MedicineDto>(medicine);
            return CreateActionResult(CustomResponseDto<MedicineDto>.Successs(201, medicinesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MedicineUpdateDto medicineUpdateDto)
        {
            await _service.UpdateAsync(_mapper.Map<Medicine>(medicineUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var medicine = await _service.GetByIdAsync(id);
            await _service.RemoveAsyn(medicine);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(204));
        }
    }
}
