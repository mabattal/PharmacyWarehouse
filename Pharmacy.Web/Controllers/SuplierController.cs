using Microsoft.AspNetCore.Mvc;
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


    }
}
