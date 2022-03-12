using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class CountryService : Service<Country>, ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(IGenericRepository<Country> repository, IUnitOfWork unitOfWork, IMapper mapper, ICountryRepository countryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<CustomResponseDto<CountryWithCountryBordersDto>> GetSingleCountryByIdWithCountryBordersAsync(int countryId)
        {
            Country country = await _countryRepository.GetSingleCountryByIdWithCountryBordersAsync(countryId);

            CountryWithCountryBordersDto countryDto = _mapper.Map<CountryWithCountryBordersDto>(country);

            return CustomResponseDto<CountryWithCountryBordersDto>.Success(200, countryDto);
        }
    }
}
