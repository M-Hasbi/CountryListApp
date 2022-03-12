using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class CountryBorderService : Service<CountryBorder>, ICountryBorderService
    {
        private readonly ICountryBorderRepository _borderRepository;
        private readonly IMapper _mapper;

        public CountryBorderService(IGenericRepository<CountryBorder> repository, IUnitOfWork unitOfWork, IMapper mapper, ICountryBorderRepository borderRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _borderRepository = borderRepository;
        }

        public async Task<CustomResponseDto<List<CountryBorderWithCountryDto>>> GetCountryBordersWithCountry()
        {
            List<CountryBorder> borders = await _borderRepository.GetCountryBordersWithCountry();

            List<CountryBorderWithCountryDto> bordersDto = _mapper.Map<List<CountryBorderWithCountryDto>>(borders);
            return CustomResponseDto<List<CountryBorderWithCountryDto>>.Success(200, bordersDto);

        }
    }
}
