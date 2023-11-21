using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Filters;
using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;
using Pharmacy.Core.Services;

namespace Pharmacy.API.Controllers
{
    public class MedicinesController : CustomBaseController
    {
        private readonly IMedicineService _medicineService;

        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMedicinesWithSuplier()
        {
            return CreateActionResult(await _medicineService.GetMedicinesWithSuplierAsync());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult(await _medicineService.GetAllAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Medicine>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _medicineService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MedicineCreateDto medicineDto)
        {
            return CreateActionResult(await _medicineService.AddAsync(medicineDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MedicineUpdateDto medicineDto)
        {
            return CreateActionResult(await _medicineService.UpdateAsync(medicineDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Medicine>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _medicineService.RemoveAsync(id));
        }

        [HttpPost("SaveAll")]
        public async Task<IActionResult> SaveAll(List<MedicineDto> medicinesDtos)
        {
            return CreateActionResult(await _medicineService.AddRangeAsync(medicinesDtos));
        }

        [HttpDelete("RemoveAll")]
        public async Task<IActionResult> RemoveAll(List<int> ids)
        {
            return CreateActionResult(await _medicineService.RemoveRangeAsync(ids));
        }

        [HttpDelete("Any/{id}")]
        public async Task<IActionResult> Any(int id)
        {
            return CreateActionResult(await _medicineService.AnyAsync(x => x.Id == id));
        }
    }
}
