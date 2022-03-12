using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

    }
}
