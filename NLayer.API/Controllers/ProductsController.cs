using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{


    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICountryBorderService _service;

        public ProductsController(IMapper mapper, ICountryBorderService productService)
        {
          
            _mapper = mapper;
            _service = productService;
        }


        /// GET api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult>  GetProductsWithCategory()
        {

            return CreateActionResult(await _service.GetProductsWithCategory());
        }





        /// GET api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<CountryBorderDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<CountryBorderDto>>.Success(200, productsDtos));
        }

       
    [ServiceFilter(typeof(NotFoundFilter<CountryBorder>))]
        // GET /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<CountryBorderDto>(product);
            return CreateActionResult(CustomResponseDto<CountryBorderDto>.Success(200, productsDto));
        }



        [HttpPost]
        public async Task<IActionResult> Save(CountryBorderDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<CountryBorder>(productDto));
            var productsDto = _mapper.Map<CountryBorderDto>(product);
            return CreateActionResult(CustomResponseDto<CountryBorderDto>.Success(201, productsDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(CountryBorderUpdateDto productDto)
        {
             await _service.UpdateAsync(_mapper.Map<CountryBorder>(productDto));
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
      
        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);


         

            await _service.RemoveAsync(product);
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
