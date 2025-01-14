﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{


    public class CountryBordersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICountryBorderService _service;

        public CountryBordersController(IMapper mapper, ICountryBorderService countryBorderService)
        {

            _mapper = mapper;
            _service = countryBorderService;
        }


        /// GET api/countryborders/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCountryBordersWithCountry()
        {

            return CreateActionResult(await _service.GetCountryBordersWithCountry());
        }





        /// GET api/CountryBorders
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<CountryBorder> countryBorders = await _service.GetAllAsync();
            List<CountryBorderDto> countryBordersDtos = _mapper.Map<List<CountryBorderDto>>(countryBorders.ToList());
            return CreateActionResult(CustomResponseDto<List<CountryBorderDto>>.Success(200, countryBordersDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<CountryBorder>))]
        // GET /apiCountryBorders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {


            CountryBorder countryBorder = await _service.GetByIdAsync(id);
            CountryBorderDto countryBordersDto = _mapper.Map<CountryBorderDto>(countryBorder);
            return CreateActionResult(CustomResponseDto<CountryBorderDto>.Success(200, countryBordersDto));
        }



        [HttpPost]
        public async Task<IActionResult> Save(CountryBorderDto countryBorderDto)
        {
            CountryBorder countryBorder = await _service.AddAsync(_mapper.Map<CountryBorder>(countryBorderDto));
            CountryBorderDto countryBordersDto = _mapper.Map<CountryBorderDto>(countryBorder);
            return CreateActionResult(CustomResponseDto<CountryBorderDto>.Success(201, countryBordersDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(CountryBorderUpdateDto countryBorders)
        {
            await _service.UpdateAsync(_mapper.Map<CountryBorder>(countryBorders));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        // DELETE api/CountryBorders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            CountryBorder countryBorders = await _service.GetByIdAsync(id);




            await _service.RemoveAsync(countryBorders);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
