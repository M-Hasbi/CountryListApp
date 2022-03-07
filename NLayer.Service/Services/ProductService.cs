using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<CountryBorder>, ICountryBorderService
    {
        private readonly ICountryBorderRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<CountryBorder> repository, IUnitOfWork unitOfWork, IMapper mapper, ICountryBorderRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<CountryBorderWithCountryDto>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWitCategory();

            var productsDto = _mapper.Map<List<CountryBorderWithCountryDto>>(products);
            return CustomResponseDto<List<CountryBorderWithCountryDto>>.Success(200, productsDto);

        }
    }
}
