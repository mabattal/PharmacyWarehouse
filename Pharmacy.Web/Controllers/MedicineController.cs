using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Core.DTOs;
using Pharmacy.Web.Services;

namespace Pharmacy.Web.Controllers
{
    public class MedicineController : Controller
    {
        private readonly MedicineApiService _medicineApiService;
        private readonly SuplierApiService _supplierApiService;

        public MedicineController(MedicineApiService medicineApiService, SuplierApiService supplierApiService)
        {
            _medicineApiService = medicineApiService;
            _supplierApiService = supplierApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _medicineApiService.GetMedicinesWithSuplierAsync());
        }

        public async Task<IActionResult> Save()
        {
            var supliersDto = await _supplierApiService.GetAllAsync();
            ViewBag.supliers = new SelectList(supliersDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(MedicineDto medicineDto)
        {
            if (ModelState.IsValid)
            {
                await _medicineApiService.SaveAsync(medicineDto);
                return RedirectToAction(nameof(Index));
            }

            var supliersDto = await _supplierApiService.GetAllAsync();
            ViewBag.supliers = new SelectList(supliersDto, "Id", "Name");
            return View();
        }

        //[ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var medicine = await _medicineApiService.GetByIdAsync(id);
            var suplierDto = await _supplierApiService.GetAllAsync();
            ViewBag.supliers = new SelectList(suplierDto, "Id", "Name", medicine.SuplierId);

            return View(medicine);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MedicineDto medicineDto)
        {
            if (ModelState.IsValid)
            {
                await _medicineApiService.UpdateAsync(medicineDto);
                return RedirectToAction(nameof(Index));
            }

            var supliersDto = await _supplierApiService.GetAllAsync();
            ViewBag.supliers = new SelectList(supliersDto, "Id", "Name", medicineDto.SuplierId);

            return View(medicineDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _medicineApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
