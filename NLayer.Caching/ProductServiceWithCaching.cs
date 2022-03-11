using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System.Linq.Expressions;

namespace NLayer.Caching
{
    public class ProductServiceWithCaching : ICountryBorderService
    {
        private const string CacheProductKey = "countryBordersCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ICountryBorderRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceWithCaching(IUnitOfWork unitOfWork, ICountryBorderRepository repository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _repository.GetCountryBordersWithCountry().Result);
            }


        }

        public async Task<CountryBorder> AddAsync(CountryBorder entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public async Task<IEnumerable<CountryBorder>> AddRangeAsync(IEnumerable<CountryBorder> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<CountryBorder, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryBorder>> GetAllAsync()
        {

            var products = _memoryCache.Get<IEnumerable<CountryBorder>>(CacheProductKey);
            return Task.FromResult(products);
        }

        public Task<CountryBorder> GetByIdAsync(int id)
        {
            var product = _memoryCache.Get<List<CountryBorder>>(CacheProductKey).FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new NotFoundExcepiton($"{typeof(CountryBorder).Name}({id}) not found");
            }

            return Task.FromResult(product);
        }

        public Task<CustomResponseDto<List<CountryBorderWithCountryDto>>> GetCountryBordersWithCountry()
        {
            var products = _memoryCache.Get<IEnumerable<CountryBorder>>(CacheProductKey);

            var productsWithCategoryDto = _mapper.Map<List<CountryBorderWithCountryDto>>(products);

            return Task.FromResult(CustomResponseDto<List<CountryBorderWithCountryDto>>.Success(200, productsWithCategoryDto));
        }

        public async Task RemoveAsync(CountryBorder entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<CountryBorder> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task UpdateAsync(CountryBorder entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public IQueryable<CountryBorder> Where(Expression<Func<CountryBorder, bool>> expression)
        {
            return _memoryCache.Get<List<CountryBorder>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }


        public async Task CacheAllProductsAsync()
        {
            _memoryCache.Set(CacheProductKey, await _repository.GetAll().ToListAsync());

        }
    }
}
