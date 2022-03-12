using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class CountriesController : Controller
    {//TODO

        private readonly CountryApiService _countryApiService;
        public CountriesController(CountryApiService countryApiService)
        {

            _countryApiService = countryApiService;
        }


        public async Task<IActionResult> Index()
        {

            return View(await _countryApiService.GetAllAsync());
        }

        public async Task<IActionResult> Save()
        {
            var countriesDto = await _countryApiService.GetAllAsync();



            ViewBag.countries = new SelectList(countriesDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CountryDto countryDto)

        {


            if (ModelState.IsValid)
            {

                await _countryApiService.SaveAsync(countryDto);


                return RedirectToAction(nameof(Index));
            }

            var countriesDto = await _countryApiService.GetAllAsync();



            ViewBag.countries = new SelectList(countriesDto, "Id", "Name");
            return View();
        }
    }
}
