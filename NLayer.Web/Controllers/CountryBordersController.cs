using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class CountryBordersController : Controller
    {

        private readonly CountryBorderApiService _countryBorderApiService;
        private readonly CountryApiService _countryApiService;

        public CountryBordersController(CountryApiService countryApiService, CountryBorderApiService countryBorderApiService)
        {
            _countryApiService = countryApiService;
            _countryBorderApiService = countryBorderApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _countryBorderApiService.GetCountryBordersWithCountryAsync());
        }

        public async Task<IActionResult> Save()
        {
            var countriesDto = await _countryApiService.GetAllAsync();

           

            ViewBag.categories = new SelectList(countriesDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CountryBorderDto countryBorderDto)

        {


            if (ModelState.IsValid)
            {

                await _countryBorderApiService.SaveAsync(countryBorderDto);

               
                return RedirectToAction(nameof(Index));
            }

            var countriesDto = await _countryApiService.GetAllAsync();

           

            ViewBag.categories = new SelectList(countriesDto, "Id", "Name");
            return View();
        }


        [ServiceFilter(typeof(NotFoundFilter<CountryBorder>))]
        public async Task<IActionResult> Update(int id)
        {
            var countryBorder = await _countryBorderApiService.GetByIdAsync(id);


            var countriesDto = await _countryApiService.GetAllAsync();

            

            ViewBag.countries = new SelectList(countriesDto, "Id", "Name",countryBorder.CountryId);

            return View(countryBorder);

        }
        [HttpPost]
        public async Task<IActionResult> Update(CountryBorderDto countryBorderDto)
        {
            if(ModelState.IsValid)
            {

                await _countryBorderApiService.UpdateAsync(countryBorderDto); 

                return RedirectToAction(nameof(Index));

            }

            var countriesDto = await  _countryApiService.GetAllAsync();

         

            ViewBag.countries = new SelectList(countriesDto, "Id", "Names", countryBorderDto.CountryId);

            return View(countryBorderDto);

        }


        public async Task<IActionResult>  Remove(int id)
        {
            await _countryBorderApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
