using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CountriesController : CustomBaseController
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            IEnumerable<Core.Country> countries = await _countryService.GetAllAsync();

            List<CountryDto> countriesDto = _mapper.Map<List<CountryDto>>(countries.ToList());

            return CreateActionResult(CustomResponseDto<List<CountryDto>>.Success(200, countriesDto));

        }


        // api/categories/GetSingleCountryByIdWithCountryBorders/2
        [HttpGet("[action]/{countryId}")]
        public async Task<IActionResult> GetSingleCountryByIdWithCountryBorders(int countryId)
        {

            return CreateActionResult(await _countryService.GetSingleCountryByIdWithCountryBordersAsync(countryId));

        }


        [HttpPost]
        public async Task<IActionResult> Save(CountryDto categoryDTO)
        {
            var newCategory = await _countryService.AddAsync(_mapper.Map<Country>(categoryDTO));

            return Created(string.Empty, _mapper.Map<CountryDto>(newCategory));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CountryDto categoryDTO)
        {
            await _countryService.UpdateAsync(_mapper.Map<Country>(categoryDTO));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Country>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _countryService.GetByIdAsync(id).Result;

            _countryService.RemoveAsync(category);
            return NoContent();
        }

    }
}
