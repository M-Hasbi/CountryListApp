using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class CountriesController : Controller
    {
        private readonly CountryApiService _countryApiService;
        private readonly IMapper _mapper;
        public CountriesController(CountryApiService countryApiService, IMapper mapper)
        {
            _countryApiService = countryApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _countryApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CountryDto>>(categories));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryDto categoryDTO)
        {
            await _countryApiService.AddAsync(categoryDTO);
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter<Country>))]
        public async Task<IActionResult> Update(int id)
        {
            var country = await _countryApiService.GetByIdAsync(id);

            return View(country);

        }
        [HttpPost]
        public async Task<IActionResult> Update(CountryDto countryDto)
        {
            if (ModelState.IsValid)
            {

                await _countryApiService.UpdateAsync(countryDto);

                return RedirectToAction(nameof(Index));

            }
            return View(countryDto);

        }

        [ServiceFilter(typeof(NotFoundFilter<Country>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryApiService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
