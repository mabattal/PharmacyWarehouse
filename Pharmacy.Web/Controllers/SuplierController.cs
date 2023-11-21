using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Core.DTOs;
using Pharmacy.Web.Services;

namespace Pharmacy.Web.Controllers
{
    public class SuplierController : Controller
    {
        private readonly SuplierApiService _suplierApiService;

        public SuplierController(SuplierApiService suplierApiService)
        {
            _suplierApiService = suplierApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _suplierApiService.GetAllAsync());
        }

        public async Task<IActionResult> Save()
        {           

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(SuplierDto suplierDto)
        {
            if (ModelState.IsValid)
            {
                await _suplierApiService.SaveAsync(suplierDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _suplierApiService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SuplierDto suplierDto)
        {
            if (ModelState.IsValid)
            {
                await _suplierApiService.UpdateAsync(suplierDto);
                return RedirectToAction(nameof(Index));
            }

            return View(suplierDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _suplierApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
